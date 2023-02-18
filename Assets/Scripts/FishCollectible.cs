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
    public GameObject audioManager;
    public GameObject fishingScript;

    // Start is called before the first frame update
    void Start()
    {
        firebaseManager = GameObject.Find("FirebaseManager");
        audioManager = GameObject.Find("AudioManager");
        fishingScript = GameObject.Find("RightHand Controller");
        score = 2;
    }
    public void CollectedFish()
    {
        if (!collected && firebaseManager != null)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFish(score);
            collected = true;
            audioManager.GetComponent<AudioManager>().CollectFishAudio();
        }

        if (!collected)
        {
            fishingScript.GetComponent<FishingScript>().StartCollectedFish();
            collected = true;
        }
    }
}
