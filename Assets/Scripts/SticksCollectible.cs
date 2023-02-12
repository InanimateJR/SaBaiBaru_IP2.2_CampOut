using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SticksCollectible : MonoBehaviour
{
    public GameObject firebaseManager;
    public bool collected = false;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 1;
        firebaseManager = GameObject.Find("FirebaseManager");
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void CollectedSticks()
    {
        if (!collected)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateSticks(score);
            collected = true;
        }
    }
}
