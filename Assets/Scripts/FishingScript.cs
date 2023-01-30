using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

// Demo a bit of Fishing. Includes lw demo of
// creating guiText, LineRenderer, Coroutine, PingPong, Mini-game

// Setup 1: Make a depression in your terrain and add Unity (Free/Pro) Water.
// Add to Water MeshCollider marked IsTrigger=Yes/Check.
// Add supplemental script to the Water (QM_WaterProps) which has public bool isFishable.

// Setup 2: Add this script to your player

// Setup 3: Create a prefab "pole" - a stretched, scaled cube will do, or get fancy and find/add
// a 3D model. At the outer tip of the pole, add an empty GameObject to use as the start
// of the LineRenderer; set the empty GameObject in Inspector as lineStart.

// Setup 4: Adjust the position & rotation of the pole in your player's hand so that it
// looks right, pointing out and up; this code demo assumes the pole is in player's hand.
// Adapt to your own code to swap it in if necessary.

// Play, move to Water, press F to fish...a green circle appears, move mouse into it
// and press G before fish reaches jump apex

public class FishingScript: MonoBehaviour
{

    // Set public variables in Inspector
    public GameObject pole;                    // Assign a fis$$anonymous$$ng pole prefab in Inspector; tilt & angle to your liking
    public Transform lineStart;                // Create/assign empty GameObject at the tip of the pole

    public int minFishingDistance;            // Min distance (7ish)
    public int maxFishingDistance;            // Max distance (28ish) 
    public bool wasInterrupted;                // Interrupted flag (moved, mob attacked, etc); public for outside access
    public float fishJumpingSpeed;            // Adjust jumpming speed (3ish)

    private RaycastHit hit;
    public GameObject scriptTarget;        // Create primitive sphere for scriptTarget, replace with fish if hit
    public GameObject newBobber;
    public GameObject fish;                // Create primitive "fish" (replace with model if you have one)
    public GameObject newFish;
    private GameObject setHook;                // Sphere appears to click
    private float fishJumpHeight;            // Height of fish jump
    private Vector3 startPos;                // Hold player starting position on cast
    private bool fishjump, fishOn, noNibble;     // Simple states

    public float fishDistance = 1f;         // Define distance between fish and fishing rod on catching fish in inspector
    public float fishRetrieveSpeed = 10f;  // Define speed of fish retrieval
    public bool destroyFish;
    private bool fishCaughtSuccess;
    public float interruptDistance = 4f;    // Define the distance in which the player can move from the start fishing position before the fishing is interrupted
    public Transform raycastOrigin;

    public ActionBasedController controller;
    public bool activateButtonPressed;
    public bool rodInHand;

    private void Awake()
    {
        wasInterrupted = false;

        // Set some defaults if unset
        if (maxFishingDistance <= 0)
        {
            maxFishingDistance = 28;
        }

        if (minFishingDistance < 0)
        {
            minFishingDistance = 7;
        }

        if (fishJumpingSpeed <= 0)
        {
            fishJumpingSpeed = 3f;
        }
    }

    private void Start()
    {
        controller.activateAction.action.performed += Action_performed;
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        activateButtonPressed = true;
        Debug.Log("fishjump" + fishjump);
        Debug.Log("rodInHand" + rodInHand);
    }

    public void CheckIfInHand()
    {
        if (rodInHand)
        {
            rodInHand = false;
            if (setHook != null)
            {
                DestroyImmediate(setHook);
            }
        }

        else if (!rodInHand)
        {
            rodInHand = true;
        }
    }

    void Update()
    {

        if (pole == null || lineStart == null)
        {
            return;
        }

        // Start Fishing via 'F'; modify for your game and don't do this at all
        // instead have your game's action dispatcher do GetComponent<FishingScript>().ActionDispatcher();
        // on hotkey press, icon click, whatever
        if (Input.GetKeyUp(KeyCode.F))
        {
            ActionListener();
        }

        if (!rodInHand)
        {
            ActionInit();
        }

        if (activateButtonPressed && !fishjump && rodInHand)
        {
            ActionListener();
            activateButtonPressed = false;
        }

        if (newFish != null && fishCaughtSuccess)
        {
            if (Vector3.Distance(newFish.transform.position, lineStart.transform.position) >= fishDistance)
            {
                newFish.transform.position = Vector3.MoveTowards(newFish.transform.position, lineStart.position, fishRetrieveSpeed * Time.deltaTime);
                newFish.transform.LookAt(lineStart.transform);
            }
            
            else
            {
                fishCaughtSuccess = false;
                newFish.AddComponent<Rigidbody>();
                newFish.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());

                // Make newFish null to ensure that it does not get deleted if player drops fishing rod
                newFish = null;
            }
        }
    }


    public void ActionListener()
    {

        /* Check your game's action dispatcher, make sure player isn't in combat, incapacitated, etc
        if(!playerHasControl)
            return;
        */

        /* If the fishing pole isn't already in your player's hand, swap it in
        if(playerDoesNotHavePole)...
        */

        ActionInit();

        // Raycast mouse position looking for Water
        //Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Assumes target Water has MeshCollider isTrigger=Yes and 
        // player can interact with layer Water is on (Water, by default)
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            ActionChecks();
        }

        else
        {
            return;
        }
    }


    private void ActionInit()
    {
        // [Re]set states
        wasInterrupted = false;
        fishOn = false;
        fishjump = false;

        if (newFish == null)
        {
            destroyFish = false;
        }

        if (newFish != null)
        {
            destroyFish = true;
            newFish.AddComponent<Rigidbody>();
            newFish.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        StopAllCoroutines();

        /*if (scriptTarget.gameObject != null)
        {
            scriptTarget.SetActive(false);
        }*/

        if (newBobber != null)
        {
            Destroy(newBobber);
        }

        if (pole.gameObject.GetComponent<LineRenderer>() != null)
        {
            DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());
        }
    }

    private void ActionChecks()
    {
        // Did we hit fishable Water with Raycast? This is determined by simple bool on supplemental 
        // script QM_WaterProps; you could do something different of course. The idea is that our player should not
        // be able to fish everywhere there's water (i.e perhaps an indoor scene, sacred aqueduct, etc)

        if (hit.transform.gameObject.tag != "Water")
        {
            return;
        }

        // Inventory check? Up to you if you want to check inventory now/return if it's full
        // or check at the very end; either way actual Inventory is out of scope for all of this

        // Check Distance
        float _dist = Vector3.Distance(transform.position, hit.point);

        if (_dist < minFishingDistance)
        {
            Debug.Log("You scare away the fish; try casting further away.");
            return;
        }

        if (_dist > maxFishingDistance)
        {
            Debug.Log("Out of range.");
            return;
        }

        // Demo create Primitive object instead of using a prefab
        //scriptTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;

        // Set "bobber" properties
        //scriptTarget.transform.position = hit.point;
        newBobber = Instantiate(scriptTarget);
        newBobber.transform.position = hit.point;

        // Demo creating guiText
        GameObject fishingUIText = new GameObject();

        fishingUIText.AddComponent(typeof(Text));

        fishingUIText.transform.position = new Vector3(.43f, .8f);

        fishingUIText.GetComponent<Text>().fontSize = 18;
        fishingUIText.GetComponent<Text>().text = "You cast your line...";

        Destroy(fishingUIText, 2.5f);

        StartCoroutine(ActionMain());
    }
 
 
    private IEnumerator ActionMain()
    {

        // Scale according to your taste and WaitForSeconds value
        int fishingTimer = 1000;
        int thisRun = fishingTimer;
        bool runningMiniGame = false;

        // Randoms
        // How far out of water does fish breach? Shorter = more difficult
        fishJumpHeight = Random.Range(3, 5);
        Vector3 fishJumpTarget = new Vector3(hit.point.x, hit.point.y + fishJumpHeight, hit.point.z);

        // Random 0...1; noNibble means dead cast (but still cycles). You could adjust hard-coded ".2"
        // based on playerSkill, bait/gear quality, buff, etc
        float noBites = Random.value;
        if (noBites <= .10)
        {
            noNibble = true;
        }
        else
        {
            noNibble = false;
        }

        // Range (within fishingTimer) that fish will bite
        // Leave enough room for cycle to complete on low
        int biteAt = Random.Range(350, 500);

        // If LineRenderer components are somehow still around, get rid of them
        // to avoid errors, duplicate lines
        if (pole.gameObject.GetComponent<LineRenderer>() != null)
        {
            DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());
        }

        // Demo create LineRenderer via runtime script
        LineRenderer fishLine = pole.gameObject.AddComponent<LineRenderer>();
        Vector3 v1 = lineStart.position;
        //Vector3 v2 = scriptTarget.transform.position;
        Vector3 v2 = newBobber.transform.position;
        fishLine.startColor = Color.green;
        fishLine.endColor = Color.green;

        fishLine.startWidth = (0.005f);
        fishLine.endWidth = (0.007f);

        fishLine.positionCount = (2);
        fishLine.SetPosition(0, v1);

        if (newBobber != null)
        {
            fishLine.SetPosition(1, v2);
        }
        else if (newBobber == null)
        {
            Vector3 v3 = newFish.transform.position;
            Debug.Log("SetPosition1");
            fishLine.SetPosition(1, v3);
        }

        fishLine.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));

        // Player movement cancels action
        Vector3 startPos = transform.position;

        // ------------- MAIN ----------------

        while(!wasInterrupted && thisRun > 0)
        {
            // Adjust LineRenderer component for animation sway, player rotate, fish jump, etc
            v1 = lineStart.position;

            if (fishLine != null)
            {
                fishLine.SetPosition(0, v1);
            }

            if (newBobber == null && newFish != null)
            {
                Debug.Log("SetPosition2");
                v2 = newFish.transform.position;
            }
            else if (newBobber != null)
            {
                //Debug.Log("Bobber position");
                v2 = newBobber.transform.position;
            }

            if (fishLine != null)
            {
                fishLine.SetPosition(1, v2);
            }

            if (!fishOn && newBobber != null)
            {
                //scriptTarget.GetComponent<Animator>().SetBool("BobbingOn", true);
                newBobber.transform.Find("FishingBobber").GetComponent<Animator>().SetBool("BobbingOn", true);
            }

            // When thisRun equals Random biteAt, "Fish On!" (unless it's a dead cycle)
            if (!noNibble && thisRun == biteAt && newBobber != null)
            {
                //scriptTarget.GetComponent<Animator>().SetBool("BobbingOn", false);
                newBobber.transform.Find("FishingBobber").GetComponent<Animator>().SetBool("BobbingOn", false);

                FishOn();
            }

            // Breach/jump fish; adjust "7" to your speed taste. Player has the interval between 
            // fish breach to apex of jump to react, otherwise fail

            if (fishjump && newFish != null)
            {
                newFish.transform.Translate(Vector3.up * Time.deltaTime * fishJumpingSpeed);
                newFish.transform.LookAt(lineStart);

                // Demo mini-game
                if (!runningMiniGame)
                {
                    StartCoroutine(MiniGame());
                    runningMiniGame = true;
                }

                // Has fish reached apex?
                if (newFish.transform.position.y >= fishJumpTarget.y)
                {
                    fishjump = false;
                    destroyFish = true;
                    StopCoroutine("MiniGame()");
                    Debug.Log("Fish reach apex");
                    newFish.AddComponent<Rigidbody>();
                }
            }

            // If the fish falls back to water, cycle is over/fail; dual-purposing wasInterrupted
            // to end Coroutine
            if (newFish != null)
            {
                if (fishOn && newFish.transform.position.y < hit.point.y)
                {
                    wasInterrupted = true;
                }
            }

            // Movement cancels action
            if (Vector3.Distance(startPos, transform.position) > interruptDistance)
            {
                Debug.Log("You stop fishing.");
                wasInterrupted = true;
                if (newFish != null)
                {
                    newFish.AddComponent<Rigidbody>();
                    newFish.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                    destroyFish = true;
                }
            }

            // Decrement counter
            if (!fishjump)
            {
                thisRun--;
            }

            // If you change Wait len, remember to scale other values
            yield return new WaitForSeconds(0.01f);
        }
 
         // ------------- end WHILE ----------------
 
        if (noNibble)
        {

            GameObject fishingUIText = new GameObject();

            fishingUIText.AddComponent(typeof(Text));
            fishingUIText.transform.position = new Vector3(.43f, .85f);
            fishingUIText.GetComponent<Text>().fontSize = 18;
            fishingUIText.GetComponent<Text>().text = "The fish aren't biting";
 
            Destroy(fishingUIText, 2.5f);
        }
 
        // Reset states for next run
        ActionInit();
 
        // The End.
 
    }
 
 
    private IEnumerator MiniGame()
    {
 
        GameObject fishingUIText = new GameObject();
 
        fishingUIText.AddComponent(typeof(Text));
 
        fishingUIText.transform.position = new Vector3(.35f, .8f);
 
        fishingUIText.GetComponent<Text>().fontSize = 18;
        fishingUIText.GetComponent<Text>().color = Color.green;
        fishingUIText.GetComponent<Text>().text = "Set the hook! [Press G with Mouse in Circle]";
 
        Destroy(fishingUIText, 2);
 
        setHook = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
 
        // Set "setHook" properties
        float setHookX = Random.Range(-3, 3);
        float setHookY = Random.Range(-1, 1);
 
        Vector3 setHookTarget = new Vector3(hit.point.x + setHookX, hit.point.y + fishJumpHeight + setHookY, hit.point.z);
 
        setHook.transform.position = setHookTarget;
 
        setHook.GetComponent<Renderer>().material.color = Color.green;
 
        setHook.transform.localScale = new Vector3(.7f, .7f, .7f);
        setHook.name = "setHook";
 
        bool miniGameDone = false;
 
        while (fishjump && !miniGameDone)
        {
 
            // CODE FOR PC CONTROLS

            // Press G to set hook
            /*if (Input.GetKeyUp(KeyCode.E))
            {
                RaycastHit hitInfo = new RaycastHit();
 
                if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity))
                {
                    if (hitInfo.transform.name == setHook.name)
                    {
                        DestroyImmediate(setHook);
                        DestroyImmediate(fishingUIText);
                        DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());
                        miniGameDone = ActionSuccess();
                    }
                }
            }*/


            if (activateButtonPressed && rodInHand)
            {
                activateButtonPressed = false;
                RaycastHit hitInfo = new RaycastHit();

                if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity))
                {
                    if (hitInfo.transform.name == setHook.name)
                    {
                        DestroyImmediate(setHook);
                        DestroyImmediate(fishingUIText);
                        //DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());
                        miniGameDone = ActionSuccess();
                    }
                }
            }

            yield return null;
        }
 
        DestroyImmediate(setHook);
        DestroyImmediate(fishingUIText);
    }
 
    private void FishOn()
    {

        // This bit uses a Primitive Sphere. If you have a fish model you could
        // use that instead, swapping out this code for that

        // Get rid of "bobber"
        //scriptTarget.SetActive(false);
        Destroy(newBobber);

        // Create "fish"
        //scriptTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
        newFish = Instantiate(fish);
        newFish.transform.position = hit.point;
 
        fishOn = true;
        fishjump = true;
    }
 
 
    private bool ActionSuccess()
    {
        // This is success code; there's too many things that you could be doing in your game
        // for me to guess at: add fish to inventory, bump fishing skill, determine how fast they clicked vs
        // how far away the hit.point was and give treasure map for great click, spawn mermaid/man, 
        // bump Fishing GUI score, etc.

        // To close, we'll clean-up and put success message up

        Debug.Log("Fish Caught");
        GameObject successUIText = new GameObject();
 
        successUIText.AddComponent(typeof(Text));
 
        successUIText.transform.position = new Vector3(.35f, .85f);
 
        successUIText.GetComponent<Text>().fontSize = 18;
        successUIText.GetComponent<Text>().color = Color.white;
        successUIText.GetComponent<Text>().text = "You caught a nice fish";
 
        Destroy(successUIText, 2.5f);

        fishCaughtSuccess = true;
        fishjump = false;

        return true;
    }
 
 }
