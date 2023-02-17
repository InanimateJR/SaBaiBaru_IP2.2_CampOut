using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public PersonalScores personalScores;
    public Transform TeleportArea;
    private Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport()
    {
        SceneManager.LoadScene(0);
        PlayerTransform.position = TeleportArea.position;
        personalScores.GetPlayerScores();
    }
}
