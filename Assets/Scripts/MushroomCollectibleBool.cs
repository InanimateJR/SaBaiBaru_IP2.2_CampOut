using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
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

    Vector3 startPosition;
    Rigidbody mushroomRigidbody;
    bool objectMoved;

    // Start is called before the first frame update
    void Start()
    {
        if (poisonous)
        {
            score = -1;
        }
        else
        {
            score = 1;
        }
        firebaseManager = GameObject.Find("FirebaseManager");
        startPosition = transform.position;
        mushroomRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != startPosition && !objectMoved)
        {
            mushroomRigidbody.isKinematic = false;
            mushroomRigidbody.useGravity = true;
            objectMoved = true;
        }
    }

    public void CollectedMushroom()
    {
        if (!collected)
        {
            firebaseManager.GetComponent<SimpleFirebaseManager>().UpdateMushrooms(score);
            collected = true;
        }
    }
}
