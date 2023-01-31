using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollectible : MonoBehaviour
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

    public void collectedFish()
    {
        if (!Collected)
        {
            FirebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFish(score);
            Collected = true;
        }
    }
}
