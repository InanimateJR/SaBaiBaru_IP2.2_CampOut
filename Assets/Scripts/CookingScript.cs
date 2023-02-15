using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookingScript : MonoBehaviour
{
    private int fishNearFire = 0;
    private int edibleMushroomNearFire = 0;
    public TaskLog tlScript;

    private void Update()
    {
        if (fishNearFire > 3)
        {
            tlScript.FishesOnSticksToGroundDone();
        }
        if(edibleMushroomNearFire > 6)
        {
            tlScript.MushroomsOnSticksToGroundDone();
        }
    }
    public void OnTriggerEnter(Collider objectNearFire)
    {
        if (objectNearFire.gameObject.tag == "Fish")
        {
            Debug.Log("Fish is near fire");
            fishNearFire++;
            FoodTrigger foodTrigger = objectNearFire.gameObject.GetComponent<FoodTrigger>();
            if (foodTrigger.canCookFish == false)
            {
                foodTrigger.canCookFish = true;
            }

        }

        else if (objectNearFire.gameObject.tag == "Mushroom")
        {
            Debug.Log("Mushroom is near fire");
            edibleMushroomNearFire++;
            FoodTrigger foodTrigger = objectNearFire.gameObject.GetComponent<FoodTrigger>();
            if (foodTrigger.canCookMushroom == false)
            {
                foodTrigger.canCookMushroom = true;
            }

        }

        else if (objectNearFire.gameObject.tag == "Poison Mushroom")
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
