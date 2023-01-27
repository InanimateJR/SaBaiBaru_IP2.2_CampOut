using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloorScript : MonoBehaviour
{
    public FishingScript2 fishingScript;
    private bool confirmDestroy;

    private void Update()
    {
        if (fishingScript.destroyFish)
        {
            confirmDestroy = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroy bool: " + fishingScript.destroyFish);
        if (confirmDestroy && collision.gameObject.tag == "Fish")
        {
            Destroy(collision.gameObject);
            confirmDestroy = false;
        }
    }
}
