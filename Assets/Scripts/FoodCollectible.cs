using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectible : MonoBehaviour
{
    public GameObject firebaseManager;
    public GameObject audioManager;
    public bool collected = false;
    public bool poisonousMushroom = false;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        firebaseManager = GameObject.Find("FirebaseManager");
        audioManager = GameObject.Find("AudioManager");
        if (!poisonousMushroom)
        {
            score = 1;
        }
        else if (poisonousMushroom)
        {
            score = -1;
        }
        CollectedFood();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void CollectedFood()
    {
        if (!collected && firebaseManager != null)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFood(score);
            collected = true;
            audioManager.GetComponent<AudioManager>().CollectFoodAudio();
        }
    }
}
