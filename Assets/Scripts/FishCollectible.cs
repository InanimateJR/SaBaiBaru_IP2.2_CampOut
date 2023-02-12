using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FishCollectible : MonoBehaviour
{
    //public GameObject FirebaseManager;
    public bool collected;
    public int score;
    public GameObject firebaseManager;

    // Start is called before the first frame update
    void Start()
    {
        firebaseManager = GameObject.Find("FirebaseManager");
        score = 2;
    }
    public void CollectedFish()
    {
        if (!collected)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFish(score);
            collected = true;
            Debug.Log("Collected");
        }
    }
}
