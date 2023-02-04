using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FishCollectible : MonoBehaviour
{
    //public GameObject FirebaseManager;
    public bool collected;
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

    public void CollectedFish()
    {
        if (!collected)
        {
            //FirebaseManager.GetComponent<SimpleFirebaseManager>().UpdateFish(score);
            collected = true;
            Debug.Log("Collected");
            //fishingScript.StartCoroutine("DisplaySucess");
        }
    }
}
