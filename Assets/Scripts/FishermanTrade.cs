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
       if(other.tag == "Mushroom")
        {
            Debug.Log("Mushroom in bucket");
            numberOfMushrooms++;
        }

       if(numberOfMushrooms == 3)
        {
            Debug.Log("Mushroom quota fulfilled");
            giveMushroom.interactable = true;

            if(other.gameObject.tag == "Mushroom")
            {
                Destroy(other.gameObject);
            }

            fishRod.GetComponent<XRGrabInteractable>().enabled = true;
            fishRod.GetComponent<Rigidbody>().isKinematic = false;
            arrow.SetActive(true);
            rentRod.interactable = false;
        }
    }

}
