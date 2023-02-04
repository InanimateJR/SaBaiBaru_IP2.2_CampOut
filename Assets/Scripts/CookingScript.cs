using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookingScript : MonoBehaviour
{

    public GameObject fishToSpawn;

    public GameObject rawFish;

    bool fishToCook;

    private void Start()
    {

    }
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
}
