using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject xrOrigin;
    private Transform PlayerTransform;
    public Transform TeleportGoal;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = xrOrigin.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveToCube()
    {
        PlayerTransform.position = TeleportGoal.position;
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        //The Application loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void OnActivate()
    {
        MoveToCube();
    }
}
