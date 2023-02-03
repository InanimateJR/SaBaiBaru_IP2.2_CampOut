using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollectible : MonoBehaviour
{
    //public GameObject FirebaseManager;
    public bool collected = false;
    public int score;

    private FishingScript fishingScript;     // Reference FishingScript
    private GameObject fishingScriptObject;

    // Start is called before the first frame update
    void Start()
    {
        fishingScriptObject = GameObject.FindGameObjectWithTag("RightHand");
        // Reference script in runtime
        fishingScript = fishingScriptObject.GetComponent<FishingScript>();
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
            Debug.Log("Fishing Obj " + fishingScriptObject);
            //fishingScript.StartCoroutine("DisplaySucess");
            fishingScript.StartDisplaySuccess();
        }
    }
}
