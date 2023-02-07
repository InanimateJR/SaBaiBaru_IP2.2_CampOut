using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangerDialogue : MonoBehaviour
{
    public GameObject rangerCanvas;
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
        rangerCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        rangerCanvas.SetActive(false);
    }
}
