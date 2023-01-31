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
    public GameObject FirebaseManager;
    public bool Collected = false;
    public int score;
    public bool poisonous;
    // Start is called before the first frame update
    void Start()
    {
        if (!poisonous)
        {
            score = 1;
        }
        else if (poisonous)
        {
            score = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectedMushroom()
    {
        if (!Collected)
        {
            FirebaseManager.GetComponent<SimpleFirebaseManager>().UpdateMushrooms(score);
            Collected = true;
        }
    }
}
