using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    

    public GameObject fishToSpawn;

    public bool canCook = false;

    private void Update()
    {
        if (canCook == true)
        {
            StartCoroutine(CookingFish());
        }
    }
    public void SpawnCookedFish()
    {
        GameObject cookedFish = Instantiate(fishToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.SetActive(false);
        Debug.Log("Fish has been cooked!");

    }
    public IEnumerator CookingFish()
    {
        yield return new WaitForSeconds(5);
        SpawnCookedFish();

    }
}
