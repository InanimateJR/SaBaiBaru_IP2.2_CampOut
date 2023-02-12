using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangerDialogue : MonoBehaviour
{
    public GameObject rangerCanvas;
    public Button talkToRanger;
    public AudioManager audioManager;

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
        Button btn = talkToRanger.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void OnTriggerExit(Collider other)
    {
        rangerCanvas.SetActive(false);
    }

    void TaskOnClick()
    {
        Debug.Log("Talking to Ranger");
        audioManager.RangerAudioOn();
    }
}
