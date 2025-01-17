using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

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
    public float fishRetrieveSpeed = 5f;  // Define speed of fish retrieval
    public bool destroyFish;                // Determine if newFish should be destroyed
    public bool fishCaughtSuccess;         // Determine if fish is caught
    public float interruptDistance = 4f;    // Define the distance in which the player can move from the start fishing position before the fishing is interrupted
    public Transform raycastOrigin;

    // Reference Right Hand Controller
    public ActionBasedController controller;
    // Check if Trigger/Activate button is pressed
    public bool activateButtonPressed;
    // Check if rod is in right hand controller
    public bool rodInHand;
    // Fishing Success Panel
    public GameObject fishingSuccessPanel;
    // Fishing Fail Panel
    public GameObject fishingFailPanel;
    // Fish On Panel
    public GameObject fishOnPanel;
    // Line Casted Panel
    public GameObject lineCastedPanel;
    // Stop Fishing Panel
    public GameObject stopFishingPanel;
    // Fish Bucket Panel
    public GameObject fishBucketPanel;
    // Wait Time for Message UI to disappear
    public float waitTime = 4f;

    public bool reachedTarget;      // Check if fish has reached the fishing rod
    public bool canFish = true;       // Check if player can fish again

    public int fishesCaught;

    public TextMeshProUGUI successFishesCaughtText;
    public TextMeshProUGUI failureFishesCaughtText;

    public MeshRenderer sphereRenderer;
    public Material sphereMaterial;

    // Audio Sources
    public GameObject fishingSFXObject;
    public GameObject castLineSFXObject;

    /// SCRIPT REFERENCE
    public FishCollectible fishCollectible;
    public AudioManager audioManager;

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
        // Initialise Checking of Trigger button press
        controller.activateAction.action.performed += Action_performed;
    }

    // Check if Trigger button is pressed
    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        activateButtonPressed = true;
        Debug.Log("fishjump" + fishjump);
        Debug.Log("rodInHand" + rodInHand);
    }

    public void CheckIfInHand()
    {
        // If Rod is in hand
        if (rodInHand)
        {
            // Set rodInHand Bool to false
            rodInHand = false;

            // Reset states
            ActionInit();
            if (setHook != null)
            {
                // Destroy Green Sphere if it exists
                DestroyImmediate(setHook);
            }
        }

        // If Rod is not in hand
        else if (!rodInHand)
        {
            // Set rodInHand bool to true
            rodInHand = true;

            if (fishingFailPanel.activeSelf)
            {
                StartCoroutine("DisplayFailure");
            }

            // Turn off stopFishingPanel
            stopFishingPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (pole == null || lineStart == null)
        {
            return;
        }

        if (newFish != null && fishCollectible.collected)
        {
            canFish = true;
        }

        // PC Controls to Cast Line to fish
        if (Input.GetKeyUp(KeyCode.F))
        {
            ActionListener();
            activateButtonPressed = false;
        }

        // VR Controls to start fishing 
        if (activateButtonPressed && !fishjump && rodInHand && canFish)
        {
            ActionListener();
            activateButtonPressed = false;
        }

        if (activateButtonPressed && rodInHand && !canFish)
        {
            activateButtonPressed = false;
            StartCoroutine("DisplayFishBucket");
        }

        // Check if conditions for successful fishing are met
        if (newFish != null && fishCaughtSuccess)
        {
            // If newFish is not within fishDistance(float) of the fishing rod
            if (Vector3.Distance(newFish.transform.position, lineStart.transform.position) >= fishDistance && !reachedTarget && rodInHand)
            {
                // Move newFish towards the fishing rod tip
                newFish.transform.position = Vector3.MoveTowards(newFish.transform.position, lineStart.position, fishRetrieveSpeed * Time.deltaTime);
                // Make newFish rotate towards the Fishing Rod tip
                newFish.transform.LookAt(lineStart.transform);
            }
            
            // If newFish is within fishDistance(float) of the fishing rod
            else
            {
                reachedTarget = true;
                newFish.GetComponent<XRGrabInteractable>().enabled = true;         // Enable XRGrabInteractable component
                newFish.GetComponent<Rigidbody>().useGravity = true;                  // Set RigidBody to use gravity
                DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());     // Destroy fishingRod linerenderer
                
                // Stop Coroutines
                StopCoroutine("DisplayLineCast");
                StopCoroutine("DisplayFailure");
                StopCoroutine("DisplayFishOn");

                // Turn off UI Panels
                lineCastedPanel.SetActive(false);
                fishingFailPanel.SetActive(false);
                fishOnPanel.SetActive(false);

                // Start to display Success UI

                if (fishCollectible.collected)
                {
                    Debug.Log("StartSuccess");
                    StartCollectedFish();
                    if (fishBucketPanel.activeSelf)
                    {
                        StopCoroutine("DisplayFishBucket");
                        fishBucketPanel.SetActive(false);
                    }
                    // Set fishCaughtSuccess to false
                    fishCaughtSuccess = false;
                    // Make newFish null to ensure that it does not get deleted if player drops fishing rod
                    newFish = null;
                    fishCollectible = null;
                    reachedTarget = false;
                    canFish = true;
                }
            }
        }
    }


    public void ActionListener()
    {
        ActionInit();       // Call reset of states

        // Code for detecting Raycast On PC
        // Raycast mouse position looking for Water
        //Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Assumes target Water has MeshCollider isTrigger=Yes and 
        // player can interact with layer Water is on (Water, by default)
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            ActionChecks();     // Call code to initiate instantiating of newBobber at raycast hit location
        }

        else
        {
            return;
        }
    }


    private void ActionInit()
    {
        // [Re]set states

        // If newFish does not exist
        if (newFish == null)
        {
            fishCollectible = null;
            reachedTarget = false;
            canFish = true;
            // Disallow deleting of fish
            destroyFish = false;
            fishCaughtSuccess = false;
        }

        // If newFish exists
        if (newFish != null)
        {
            destroyFish = true;     // Allow fish to be destroyed
            newFish.GetComponent<XRGrabInteractable>().enabled = true;         // Enable XRGrabInteractable component
            newFish.GetComponent<Rigidbody>().useGravity = true;                  // Set RigidBody to use gravity
            newFish.GetComponent<Rigidbody>().velocity = Vector3.zero;
            newFish.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Debug.Log(newFish.GetComponent<Rigidbody>().velocity);

            // Turn off UI Panels
            lineCastedPanel.SetActive(false);
            fishOnPanel.SetActive(false);
            //fishingSuccessPanel.SetActive(false);
        }

        StopAllCoroutines();

        // If a fish is on the line and the player drops the fishing rod
        if (newFish != null && destroyFish && !rodInHand)
        {
            Debug.Log("Display Failure");
            // Display fishing failure UI 
            StartCoroutine("DisplayFailure");
        }

        // If a fish has not spawned and the player drops the fishing rod
        if (lineCastedPanel.activeSelf && !fishOn && !rodInHand)
        {
            // Turn off lineCasted UI
            lineCastedPanel.SetActive(false);
            // Display Stop Fishing UI 
            if (!fishingSuccessPanel.activeSelf)
            {
                StartCoroutine("DisplayStopFishing");
            }
        }

        // If Success panel is still active, turn it off
        if (fishingSuccessPanel.activeSelf && !rodInHand)
        {
            StartCoroutine("DisplaySuccess");
        }

        // If Stop Fishing panel is still active, turn it off
        if (stopFishingPanel.activeSelf && !rodInHand)
        {
            StartCoroutine("DisplayStopFishing");
        }

        // If Failure Panel is still active, turn it off
        if (fishingFailPanel.activeSelf && !rodInHand)
        {
            StopCoroutine("DisplayFailure");
            fishingFailPanel.SetActive(false);
        }

        // If Fish Bucket Panel is still active, turn it off
        if (fishBucketPanel.activeSelf && !rodInHand)
        {
            StartCoroutine("DisplayFishBucket");
        }

        // If newBobber exists
        if (newBobber != null)
        {
            // Destroy newBobber
            Destroy(newBobber);
        }

        // If fishing rod's linerenderer exists
        if (pole.gameObject.GetComponent<LineRenderer>() != null)
        {
            // Destroy linerenderer
            DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());
        }

        // Reset bool values
        wasInterrupted = false;
        fishOn = false;
        fishjump = false;
        reachedTarget = false;
        //fishCaughtSuccess = false;
    }

    private void ActionChecks()
    {
        // Check if raycast hit gameobject with tag, "Water"
        if (hit.transform.gameObject.tag != "Water")
        {
            return;
        }

        // Check Distance between raycast hit location and raycast origin
        float _dist = Vector3.Distance(transform.position, hit.point);

        // Check if raycast spot is far enough from player
        if (_dist < minFishingDistance)
        {
            Debug.Log("You scare away the fish; try casting further away.");
            return;
        }

        // Check if raycast spot is within allowed distance
        if (_dist > maxFishingDistance)
        {
            Debug.Log("Out of range.");
            return;
        }

        // Demo create Primitive object instead of using a prefab
        //scriptTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;

        // Create newBobber
        newBobber = Instantiate(scriptTarget);
        // Set newBobber location to raycast hit location
        newBobber.transform.position = hit.point;

        // Set Castline SFX location to raycast hit location
        castLineSFXObject.transform.position = hit.point;
        // Set Fishing SFX location to raycast hit location
        fishingSFXObject.transform.position = hit.point;

        // Play CastLine SFX
        audioManager.CastLineAudio();

        // Turn off Stop Fishing UI
        stopFishingPanel.SetActive(false);
        // Turn off Success UI
        fishingSuccessPanel.SetActive(false);
        // Display Line Cast UI
        StartCoroutine("DisplayLineCast");

        // Start Coroutine handling newFish and linerenderer behaviour
        StartCoroutine(ActionMain());
    }
 
 
    private IEnumerator ActionMain()
    {
        // Set values for fishing minigame
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
        Vector3 v1 = lineStart.position;        // Create new Vector3 for lineStart
        Vector3 v2 = newBobber.transform.position;      // Create new Vector3 for newBobber

        fishLine.startWidth = (0.005f);     // Set Start width of fishLine linerenderer
        fishLine.endWidth = (0.007f);       // Set end width of fishLine linerenderer

        fishLine.positionCount = (2);
        fishLine.SetPosition(0, v1);        

        // If newBobber exists
        if (newBobber != null)
        {
            fishLine.SetPosition(1, v2);
        }

        // If newBobber does not exist
        else if (newBobber == null)
        {
            Vector3 v3 = newFish.transform.position;        // Set new Vector3 for lineStart
            Debug.Log("SetPosition1");
            fishLine.SetPosition(1, v3);            // Set fishLine position to fish
        }

        // Set material for fishLine
        fishLine.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));

        // Player movement cancels action
        Vector3 startPos = transform.position;

        // ------------- MAIN ----------------
        // If game is not interrupted and this run has not run for more than specified time
        while(!wasInterrupted && thisRun > 0)
        {
            // Adjust LineRenderer component for animation sway, player rotate, fish jump, etc
            v1 = lineStart.position;

            // If fishLine line renderer exists
            if (fishLine != null)
            {
                fishLine.SetPosition(0, v1);
            }

            // If newBobber does not exist and newFish exists
            if (newBobber == null && newFish != null)
            {
                // Set newFish position to newBobber position
                v2 = newFish.transform.position;
            }

            // If newBobber exists
            else if (newBobber != null)
            {
                v2 = newBobber.transform.position;
            }

            if (fishLine != null)
            {
                fishLine.SetPosition(1, v2);
            }

            if (!fishOn && newBobber != null)
            {
                // Start playing bobbing animation
                newBobber.transform.Find("FishingBobber").GetComponent<Animator>().SetBool("BobbingOn", true);
            }

            // When thisRun equals Random biteAt, "Fish On!" (unless it's a dead cycle)
            if (!noNibble && thisRun == biteAt && newBobber != null)
            {
                // Stop playing bobbing animation
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
                    newFish.GetComponent<Rigidbody>().useGravity = true;                  // Set RigidBody to use gravity
                }
            }

            // If the fish falls back to water, cycle is over/fail; dual-purposing wasInterrupted
            // to end Coroutine
            // If newFish exists
            if (newFish != null)
            {
                // If fish has spawned and fish's y coordinate is less than raycast hit position
                if (fishOn && newFish.transform.position.y < hit.point.y)
                {
                    // Game is interrupted
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
                    newFish.GetComponent<XRGrabInteractable>().enabled = true;         // Enable XRGrabInteractable component
                    newFish.GetComponent<Rigidbody>().useGravity = true;                  // Set RigidBody to use gravity
                    destroyFish = true;     // Allow fish to be destroyed
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
        setHook = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
 
        // Set "setHook" properties
        float setHookX = Random.Range(-3, 3);
        float setHookY = Random.Range(-1, 1);
 
        Vector3 setHookTarget = new Vector3(hit.point.x + setHookX, hit.point.y + fishJumpHeight + setHookY, hit.point.z);
 
        setHook.transform.position = setHookTarget;
 
        setHook.GetComponent<Renderer>().material = sphereMaterial;
 
        setHook.transform.localScale = new Vector3(.7f, .7f, .7f);
        setHook.name = "setHook";
 
        bool miniGameDone = false;
 
        while (fishjump && !miniGameDone)
        {
 
            // CODE FOR PC CONTROLS

            // Press G to set hook
            if (Input.GetKeyUp(KeyCode.E))
            {
                activateButtonPressed = false;
                RaycastHit hitInfo = new RaycastHit();
 
                if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity))
                {
                    if (hitInfo.transform.name == setHook.name)
                    {
                        DestroyImmediate(setHook);
                        //DestroyImmediate(pole.gameObject.GetComponent<LineRenderer>());
                        miniGameDone = ActionSuccess();
                    }
                }
            }

            // If Trigger button is pressed and rod is in hand
            if (activateButtonPressed && rodInHand)
            {
                activateButtonPressed = false;      // Reset activeButtonPressed bool
                RaycastHit hitInfo = new RaycastHit();

                if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity))
                {
                    if (hitInfo.transform.name == setHook.name)
                    {
                        canFish = false;
                        DestroyImmediate(setHook);
                        miniGameDone = ActionSuccess();     // Set ActionSuccess bool to true
                    }
                }
            }

            yield return null;
        }
 
        DestroyImmediate(setHook);
    }
 
    private void FishOn()
    {
        // Get rid of "bobber"
        Destroy(newBobber);

        // Create "fish"
        newFish = Instantiate(fish);
        newFish.transform.position = hit.point;
        fishCollectible = newFish.GetComponent<FishCollectible>();

        // Play fishingSFX
        audioManager.FishingAudio();

        fishOn = true;
        fishjump = true;

        StopCoroutine("DisplayLineCast");       
        lineCastedPanel.SetActive(false);       // Turn off lineCasted UI
        StartCoroutine("DisplayFishOn");        // Start Coroutine to display FishOn panel
    }
 
    // ActionSuccess bool
    private bool ActionSuccess()
    {
        Debug.Log("Fish Caught");

        fishCaughtSuccess = true;
        fishjump = false;

        return true;
    }

    // Display and turn off success panel
    public IEnumerator DisplaySuccess()
    {
        successFishesCaughtText.text = "FISHES CAUGHT: " + fishesCaught;
        failureFishesCaughtText.text = "FISHES CAUGHT: " + fishesCaught;
        fishingSuccessPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        fishingSuccessPanel.SetActive(false);
        yield return null;
    }

    // Display and turn off Failure panel
    IEnumerator DisplayFailure()
    {
        fishingFailPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        fishingFailPanel.SetActive(false);
        yield return null;
    }

    // Display and turn off LineCast panel
    IEnumerator DisplayLineCast()
    {
        lineCastedPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        lineCastedPanel.SetActive(false);
        yield return null;
    }

    // Display and turn off FishOn panel
    IEnumerator DisplayFishOn()
    {
        fishOnPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        fishOnPanel.SetActive(false);
        yield return null;
    }

    // Display and turn off StopFishing panel
    IEnumerator DisplayStopFishing()
    {
        stopFishingPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        stopFishingPanel.SetActive(false);
        yield return null;
    }

    IEnumerator DisplayFishBucket()
    {
        fishBucketPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        fishBucketPanel.SetActive(false);
        yield return null;
    }

    public void StartCollectedFish()
    {
        Debug.Log("StartCollectedFish");
        canFish = true;
        StartCoroutine("DisplaySuccess");
        fishesCaught++;
    }
}
