using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookingScript : MonoBehaviour
{
    private int fishNearFire = 0;
    private int edibleMushroomNearFire = 0;
    public TaskLog tlScript;

    //if there are 3 and 6 fishes and mushroom near the fire respectively, strikethrough task
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
    //When food is near the fire, the collided raw food will cook
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
