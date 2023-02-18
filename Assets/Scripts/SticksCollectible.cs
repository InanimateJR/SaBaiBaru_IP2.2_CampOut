using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SticksCollectible : MonoBehaviour
{
    public GameObject firebaseManager;
    public bool collected = false;
    public int score;
    public GameObject notepad;

    // set score to 1
    void Start()
    {
        score = 1;
        firebaseManager = GameObject.Find("FirebaseManager");
        notepad = GameObject.Find("Notepad 7.0");
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void CollectedSticks()
    {
        //update firebase with sticks score
        if (!collected)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateSticks(score);
            collected = true;
            notepad.GetComponent<TaskLog>().SticksCollection();
        }
    }
}
