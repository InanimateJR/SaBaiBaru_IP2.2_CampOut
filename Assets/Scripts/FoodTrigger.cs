using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    

    public GameObject fishToSpawn;

    public bool canCook = false;

    void Update()
    {
        if (canCook == true)
        {
            canCook = false;
            
            StartCoroutine(CookingFish());
        }
    }
    public void SpawnCookedFish()
    {
        Debug.Log("cooking...2");
        GameObject cookedFish = Instantiate(fishToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Debug.Log("Fish has been cooked!");

    }
    public IEnumerator CookingFish()
    {
        Debug.Log("cooking...");
        yield return new WaitForSeconds(5);
        SpawnCookedFish();

    }
}
