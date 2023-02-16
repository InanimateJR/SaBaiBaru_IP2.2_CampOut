using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodTrigger : MonoBehaviour
{
    private GameObject notepad;

    //referencing to task log script
    public TaskLog taskLog;

    public GameObject fishToSpawn;

    public GameObject mushroomToSpawn;

    public GameObject poisonMushroomToSpawn;

    public bool canCookFish = false;

    public bool canCookMushroom = false;

    public bool fishSnappedToStick = false;

    public bool edibleMushroomSnappedToStick = false;

    public bool canCookPoisonMushroom = false;



    // Always check if the food can be cooked or not

    private void Awake()
    {
        if (this.gameObject.tag == "Fish")
        {
            notepad = GameObject.Find("Notepad 7.0");
        }
    }

    private void Start()
    {
        if (this.gameObject.tag == "Fish")
        {
            taskLog = notepad.GetComponent<TaskLog>();
        }

        edibleMushroomSnappedToStick = false;

        fishSnappedToStick = false;
    }

    void Update()
    {
        if (canCookFish == true)
        {
            canCookFish = false;
            
            StartCoroutine(CookingFish());
        }

        if (canCookMushroom == true)
        {
            canCookMushroom = false;

            StartCoroutine(CookingMushroom());
        }

        if (canCookPoisonMushroom == true)
        {
            canCookPoisonMushroom = false;

            StartCoroutine(CookingPoisonMushroom());
        }
        
        
    }
    // Switch the prefab of raw to cooked fishs
    public void SpawnCookedFish()
    {
        GameObject cookedFish = Instantiate(fishToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Fish has been cooked!");

    }
    // Switch the prefab of raw to cooked Mushrooms
    public void SpawnCookedMushroom()
    {
        GameObject cookedMuhsroom = Instantiate(mushroomToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Mushroom has been cooked!");

    }
    // Switch the prefab of raw to cooked Poison Mushrooms
    public void SpawnCookedPoisonMushroom()
    {
        GameObject cookedPoisonMushroom = Instantiate(poisonMushroomToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Poison Mushroom has been cooked!");

    }
    // Wait for 5 seconds before the Fish prefab is switched
    public IEnumerator CookingFish()
    {
        yield return new WaitForSeconds(5);
        SpawnCookedFish();

    }
    // Wait for 5 seconds before the Mushroom prefab is switched
    public IEnumerator CookingMushroom()
    {
        yield return new WaitForSeconds(5);
        SpawnCookedMushroom();

    }
    // Wait for 5 seconds before the Poison Mushroom prefab is switched
    public IEnumerator CookingPoisonMushroom()
    {
        yield return new WaitForSeconds(5);
        SpawnCookedPoisonMushroom();

    }
    // If the socket snapped to raw fish is a stick with the tag, it will be counted
    public void FishSocketCheck()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        if (myGrabbable.firstInteractorSelecting is XRSocketInteractor)
        {
            if (myGrabbable.firstInteractorSelecting.transform.tag == "CookingStickSocket")
            {
                fishSnappedToStick = true;
                taskLog.fishOnSticks++;
                Debug.Log("Fish added on stick");

                
            }
        }
    }
    //if the fish is off the socket, the count of fish on sticks will decrease
    public void FishSocketCheckExit()
    {
        if(fishSnappedToStick)
        {
            taskLog.fishOnSticks--;
            fishSnappedToStick = false;
        }
        
    }
    // If the socket snapped to edible mushroom is a stick with the tag, it will be counted
    public void EdibleMushroomSocketCheck()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        if (myGrabbable.firstInteractorSelecting is XRSocketInteractor)
        {
            if (myGrabbable.firstInteractorSelecting.transform.tag == "CookingStickSocket")
            {
                edibleMushroomSnappedToStick = true;
                taskLog.edibleMushroomOnSticks++;
                Debug.Log("Mushroom added on stick");

            }
        }
    }
    //if the mushroom is off the socket, the count of mushroom on sticks will decrease
    public void EdibleMushroomSocketCheckExit()
    {
        if(edibleMushroomSnappedToStick)
        {
            taskLog.edibleMushroomOnSticks--;
            edibleMushroomSnappedToStick = false;
        }
        
    }
}
