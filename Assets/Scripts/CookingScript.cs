using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookingScript : MonoBehaviour
{
    /*
    public GameObject fishToSpawn;

    public GameObject rawFish;


    public void SpawnCookedFish()
    {
        GameObject cookedFish = Instantiate(fishToSpawn, rawFish.transform.position, rawFish.transform.rotation);
        rawFish.SetActive(false);
        Debug.Log("Fish has been cooked!");

    }

    private void OnTriggerEnter(Collider objectNearFire)
    {
        if (objectNearFire.tag == "Fish")
        {
            Debug.Log("Fish is near fire");
            rawFish = objectNearFire.gameObject;
            StartCoroutine(CookingFish());
        }

    }

    IEnumerator CookingFish()
    {
        yield return new WaitForSeconds(5);
        SpawnCookedFish();
        
    }
    */
    
    public void OnTriggerEnter(Collider objectNearFire)
    {
        if (objectNearFire.gameObject.tag == "Fish")
        {
            Debug.Log("Fish is near fire");

            FoodTrigger foodTrigger = objectNearFire.gameObject.GetComponent<FoodTrigger>();
            if (foodTrigger.canCookFish == false)
            {
                foodTrigger.canCookFish = true;
            }

        }

        else if (objectNearFire.gameObject.tag == "Mushroom")
        {
            Debug.Log("Mushroom is near fire");

            FoodTrigger foodTrigger = objectNearFire.gameObject.GetComponent<FoodTrigger>();
            if (foodTrigger.canCookMushroom == false)
            {
                foodTrigger.canCookMushroom = true;
            }

        }

        else if (objectNearFire.gameObject.tag == " Poison Mushroom")
        {
            Debug.Log("Poison Mushroom is near fire");

            FoodTrigger foodTrigger = objectNearFire.gameObject.GetComponent<FoodTrigger>();
            if (foodTrigger.canCookPoisonMushroom == false)
            {
                foodTrigger.canCookPoisonMushroom = true;
            }

        }

    }


}
