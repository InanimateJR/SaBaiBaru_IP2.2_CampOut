using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class FishermanTrade : MonoBehaviour
{
    public Button giveMushroom;
    public Button rentRod;
    private int numberOfMushrooms;
    public GameObject fishRod;
    public GameObject arrow;
    public List<GameObject> mushroomInBucket;
    public Image start;
    public Image end;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        giveMushroom.interactable = false;
        rentRod.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mushroom")
        {
            if (!mushroomInBucket.Contains(other.gameObject))
            {
                Debug.Log("Fish in bucket");
                mushroomInBucket.Add(other.gameObject);
                numberOfMushrooms++;
                Debug.Log(numberOfMushrooms + " " + mushroomInBucket.Count);

                if (numberOfMushrooms == 3)
                {
                    Debug.Log("Fish quota fulfilled");
                    giveMushroom.interactable = true;

                    for (int i = 2; i >= 0; --i)
                    {
                        Debug.Log("fish destroyed " + i);

                        Destroy(mushroomInBucket[i]);
                        mushroomInBucket.Remove(mushroomInBucket[i]);
                    }
                    Button btn = giveMushroom.GetComponent<Button>();
                    btn.onClick.AddListener(TaskOnClick);
                }
            }

        }

        void TaskOnClick()
        {
         
            fishRod.GetComponent<XRGrabInteractable>().enabled = true;
            fishRod.GetComponent<Rigidbody>().isKinematic = false;

            audioManager.FishermanAudioOff();
            arrow.SetActive(true);
            rentRod.interactable = false;
        }
    }

}
