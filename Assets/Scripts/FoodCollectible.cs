using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectible : MonoBehaviour
{
    public GameObject FirebaseManager;
    public bool Collected = false;
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

    public void collectedFood()
    {
        if (!Collected)
        {
            FirebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFood(score);
            Collected = true;
        }
    }
}
