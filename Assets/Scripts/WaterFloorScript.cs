using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloorScript : MonoBehaviour
{
    public FishingScript fishingScript;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroy bool: " + fishingScript.destroyFish);
        if (collision.gameObject.tag == "Fish")
        {
            Destroy(collision.gameObject);
        }
    }
}
