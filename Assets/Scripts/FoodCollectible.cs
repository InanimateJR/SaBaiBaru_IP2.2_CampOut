using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectible : MonoBehaviour
{
    public GameObject firebaseManager;
    public bool collected = false;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 1;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void CollectedFood()
    {
        if (!collected)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFood(score);
            collected = true;
        }
    }
}
