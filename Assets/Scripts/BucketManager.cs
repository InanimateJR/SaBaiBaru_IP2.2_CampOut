using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BucketManager : MonoBehaviour
{
    public FishingScript fishingScript;

    public GameObject[] fishArray;          // Array storing fish objects
    public GameObject[] fishSocketArray;    // Array storing fish socket interactors;

    int i;
    int j;

    /// TEMPORARY VARIABLES
    public int fishesScore;
    public GameObject firebaseManager;
    public bool collected;


    public void AddFishArray()
    {
        if (fishArray[i] == null)
        {
            fishArray[i] = fishingScript.newFish;
            i++;
        }
    }

    public void RemoveFishArray()
    {
        if (fishArray[i] != null)
        {
            fishArray[i] = null;
            i--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fish")
        {
            for (int j = 0; j <= 5; j++)
            {
                if (other.gameObject == fishArray[j])
                {
                    fishSocketArray[j].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fish")
        {
            for (int j = 0; j <= 5; j++)
            {
                if (other.gameObject == fishArray[j])
                {
                    fishSocketArray[j].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fish")
        {
            fishSocketArray[i].SetActive(false);
        }
    }

    public void FishSnapped()
    {
        if (!collected)
        {
            //firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFish(fishesScore);
        }
        fishingScript.StartDisplaySuccess();
    }
}
