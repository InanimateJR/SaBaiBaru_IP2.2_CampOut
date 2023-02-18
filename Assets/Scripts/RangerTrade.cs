using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class RangerTrade : MonoBehaviour
{
    private int numberOfFish = 0;
    public Button giveFish;
    public GameObject arrow;
    public Button rentLog;
    public List<GameObject> fishInBucket;
    public AudioManager audioManager;
    public GameObject matchstickBox;
    public GameObject[] matchstick;

    // Start is called before the first frame update
    void Start()
    {
        giveFish.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish")
        {
            if (!fishInBucket.Contains(other.gameObject))
            {
                Debug.Log("Fish in bucket");
                fishInBucket.Add(other.gameObject);
                numberOfFish++;
                Debug.Log(numberOfFish + " " + fishInBucket.Count);

                if (numberOfFish == 3)
                {
                    Debug.Log("Fish quota fulfilled");
                    giveFish.interactable = true;

                    for (int i = 2; i >= 0; --i)
                    {
                        Debug.Log("fish destroyed " + i);

                        Destroy(fishInBucket[i]);
                        fishInBucket.Remove(fishInBucket[i]);
                    }
                    Button btn = giveFish.GetComponent<Button>();
                    btn.onClick.AddListener(TaskOnClick);
                }
            }
            
        }

    }

    void TaskOnClick()
    {
        var logs = GameObject.FindGameObjectsWithTag("Log");
        var logCount = logs.Length;
        foreach (var log in logs)
        {
            log.GetComponent<XRGrabInteractable>().enabled = true;
            log.GetComponent<Rigidbody>().isKinematic = false;
        }
        for (int i = 0; i < matchstick.Length; i++)
        {
            matchstick[i].SetActive(true);
        }
        matchstickBox.GetComponent<XRGrabInteractable>().enabled = true;

        audioManager.RangerAudioOff();
        arrow.SetActive(true);
        rentLog.interactable = false;
    }
}
