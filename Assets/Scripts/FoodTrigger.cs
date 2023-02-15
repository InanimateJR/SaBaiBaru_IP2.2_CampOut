using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodTrigger : MonoBehaviour
{
    public TaskLog taskLog;

    public GameObject fishToSpawn;

    public GameObject mushroomToSpawn;

    public GameObject poisonMushroomToSpawn;

    public bool canCookFish = false;

    public bool canCookMushroom = false;

    public bool fishSnappedToStick = false;

    public bool edibleMushroomSnappedToStick = false;

    public bool canCookPoisonMushroom = false;

    public int fishOnSticks = 0;

    public int edibleMushroomOnSticks = 0;

    public int fishNearFire = 0;

    public int edibleMushroomNearFire = 0;

    // Always check if the food can be cooked or not

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

        if (fishOnSticks >= 3)
        {
            taskLog.allfishOnSticks = true;
            taskLog.FishesOnSticksDone();
        }

        if (edibleMushroomOnSticks >= 6)
        {
            taskLog.allEdibleMushroomOnSticks = true;
            taskLog.MushroomsOnSticksDone();
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
        Debug.Log("cooking...2");
        GameObject cookedPoisonMushroom = Instantiate(poisonMushroomToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Poison Mushroom has been cooked!");

    }
    // Wait for 5 seconds before the Fish prefab is switched
    public IEnumerator CookingFish()
    {
        Debug.Log("cooking...");
        yield return new WaitForSeconds(5);
        SpawnCookedFish();

    }
    // Wait for 5 seconds before the Mushroom prefab is switched
    public IEnumerator CookingMushroom()
    {
        Debug.Log("cooking...");
        yield return new WaitForSeconds(5);
        SpawnCookedMushroom();

    }
    // Wait for 5 seconds before the Poison Mushroom prefab is switched
    public IEnumerator CookingPoisonMushroom()
    {
        Debug.Log("cooking...");
        yield return new WaitForSeconds(5);
        SpawnCookedPoisonMushroom();

    }

    public void FishSocketCheck()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        if (myGrabbable.firstInteractorSelecting is XRSocketInteractor)
        {
            if (myGrabbable.firstInteractorSelecting.transform.tag == "CookingStickSocket")
            {
                fishOnSticks++;
            }
        }
    }

    public void FishSocketCheckExit()
    {
        if(fishSnappedToStick)
        {
            fishOnSticks--;
        }
        
    }

    public void EdibleMushroomSocketCheck()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        if (myGrabbable.firstInteractorSelecting is XRSocketInteractor)
        {
            if (myGrabbable.firstInteractorSelecting.transform.tag == "CookingStickSocket")
            {
                edibleMushroomOnSticks++;
                
            }
        }
    }
    public void EdibleMushroomSocketCheckExit()
    {
        if(edibleMushroomSnappedToStick)
        {
            edibleMushroomOnSticks--;
        }
        
    }
}
