using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishermanDialogue : MonoBehaviour
{
    public GameObject fishermanCanvas;
    public Button talkToFisherman;
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
        fishermanCanvas.SetActive(true);
        Button btn = talkToFisherman.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void OnTriggerExit(Collider other)
    {
        fishermanCanvas.SetActive(false);
    }

    void TaskOnClick()
    {
        Debug.Log("Talking to Ranger");
        audioManager.FishermanAudioOn();
    }
}
