using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishermanDialogue : MonoBehaviour
{
    public GameObject fishermanCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        fishermanCanvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        fishermanCanvas.SetActive(false);
    }
}
