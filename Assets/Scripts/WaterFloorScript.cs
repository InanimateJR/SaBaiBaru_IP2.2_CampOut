using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloorScript : MonoBehaviour
{
    public FishingScript fishingScript;  // Reference FishingScript
    public BucketManager bucketManager;   // Reference BucketManager

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroy bool: " + fishingScript.destroyFish);
        if (collision.gameObject.tag == "Fish")
        {
            Destroy(collision.gameObject);
            bucketManager.RemoveFishArray();   // Set bucketManager's fishArray[i] variable to null to avoid adding fishCount after fish is destroyed
        }
    }
}
