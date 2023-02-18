using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public GameObject xrOrigin;
    private PersonalScores personalScores;
    public Transform teleportArea;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = xrOrigin.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //teleports player to a set transform
    public void Teleport()
    {
        playerTransform.position = teleportArea.position;
    }
    //reloads scene 0
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
