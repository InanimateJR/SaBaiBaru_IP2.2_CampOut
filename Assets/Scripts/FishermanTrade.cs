using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishermanTrade : MonoBehaviour
{
    public Button button;
    private int numberOfMushrooms;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
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
            button.interactable = true;
        }
    }
}
