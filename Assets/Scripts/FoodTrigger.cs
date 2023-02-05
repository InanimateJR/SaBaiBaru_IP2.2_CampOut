using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    

    public GameObject fishToSpawn;

    public GameObject mushroomToSpawn;

    public GameObject poisonMushroomToSpawn;

    public bool canCookFish = false;

    public bool canCookMushroom = false;

    public bool canCookPoisonMushroom = false;

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
    }
    public void SpawnCookedFish()
    {
        Debug.Log("cooking...2");
        GameObject cookedFish = Instantiate(fishToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Fish has been cooked!");

    }

    public void SpawnCookedMushroom()
    {
        Debug.Log("cooking...2");
        GameObject cookedMuhsroom = Instantiate(mushroomToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Mushroom has been cooked!");

    }

    public void SpawnCookedPoisonMushroom()
    {
        Debug.Log("cooking...2");
        GameObject cookedPoisonMushroom = Instantiate(poisonMushroomToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Poison Mushroom has been cooked!");

    }

    public IEnumerator CookingFish()
    {
        Debug.Log("cooking...");
        yield return new WaitForSeconds(5);
        SpawnCookedFish();

    }

    public IEnumerator CookingMushroom()
    {
        Debug.Log("cooking...");
        yield return new WaitForSeconds(5);
        SpawnCookedMushroom();

    }

    public IEnumerator CookingPoisonMushroom()
    {
        Debug.Log("cooking...");
        yield return new WaitForSeconds(5);
        SpawnCookedPoisonMushroom();

    }
}
