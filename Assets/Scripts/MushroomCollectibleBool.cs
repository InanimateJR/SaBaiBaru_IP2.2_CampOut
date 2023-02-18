using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;

public class MushroomCollectibleBool : MonoBehaviour
{
    public GameObject firebaseManager;
    public bool collected = false;
    public int score;
    public bool poisonous;
    public GameObject notepad;

    Vector3 startPosition;
    Rigidbody mushroomRigidbody;
    bool objectMoved;
    // Start is called before the first frame update
    void Start()
    {
          //set score based on poisonous or edible
        if (poisonous)
        {
            score = -1;
        }
        else
        {
            score = 1;
        }
        firebaseManager = GameObject.Find("FirebaseManager");
        notepad = GameObject.Find("Notepad 7.0");
        startPosition = transform.position;
        mushroomRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //prevents mushroom from falling over before collected
        if (this.gameObject.transform.root.position != startPosition && !objectMoved)
        {
            mushroomRigidbody.constraints = RigidbodyConstraints.None;
            mushroomRigidbody.useGravity = true;
            objectMoved = true;
        }
    }

    public void CollectedMushroom()
    {
        //updates firebase score for mushrooms
        if (!collected)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateMushrooms(score);
            collected = true;
            if (!poisonous)
            {
                notepad.GetComponent<TaskLog>().MushroomCollected();
            }
        }
    }
}
