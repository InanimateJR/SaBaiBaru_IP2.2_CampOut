using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CookingScript : MonoBehaviour
{
    public bool foodSnapped;

    public GameObject fishToSpawn;

    public GameObject rawFish;

    private void Start()
    {
        rawFish = GameObject.FindWithTag("Fish");
    }

    
    public void SnappingGround()
    {
        var fire = GameObject.FindWithTag("fire");

        if (fire != null)
        {
            Debug.Log("Fire is present");
        }
    }

    void SnapFood()
    {
        foodSnapped = true;
    }

    public void SpawnCookedFish()
    {
        GameObject cookedFish = Instantiate(fishToSpawn, rawFish.transform.position, rawFish.transform.rotation);
        rawFish.SetActive(false);
        
    }

}
