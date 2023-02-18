using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FishCollectible : MonoBehaviour
{
    public bool collected;
    public int score;
    public GameObject firebaseManager;
    public GameObject audioManager;

    // fishes are worth 2 point each
    void Start()
    {
        firebaseManager = GameObject.Find("FirebaseManager");
        audioManager = GameObject.Find("AudioManager");
        score = 2;
    }
    //send score to update firebase
    public void CollectedFish()
    {
        if (!collected && firebaseManager != null)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFish(score);
            collected = true;
            audioManager.GetComponent<AudioManager>().CollectFishAudio();
        }
    }
}
