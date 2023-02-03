using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TaskLog : MonoBehaviour
{
    // Prefab of object to spawn
    public TMP_Text playerPrefab;

    // Keep track of which instance is the “active” GameManager.
    public static TaskLog instance;

    // Link player script
    //private Player activePlayer;

    // Store number of pegs collected
    public int pegsCollected;

    // Assign object "firstPeg" in inventory
    public TMP_Text firstPegUI;

    // Assign object "secondPeg" in inventory
    public TMP_Text secondPegUI;

    // Assign object "thirdPeg" in inventory
    public TMP_Text thirdPegUI;

    // Assign object "fourthPeg" in inventory 
    public TMP_Text fourthPegUI;

    //  Assign Inventory UI
    public GameObject listUI;

    // Whether firstPeg is collected or not
    public bool firstPegCollected = false;

    // Whether secondPeg is collected or not
    public bool secondPegCollected = false;

    // Whether thirdPeg is collected or not
    public bool thirdPegCollected = false;

    // Whether fourthPeg is collected or not
    public bool fourthPegCollected = false;

    // All 4 pegs are not hammered in 
    private bool completedPegs = false;


    void Start()
    {
        // Number of items collected starts at 0
        pegsCollected = 0;
    }

    void Update()
    {
        //if hammering not commplete
        if (!completedPegs)
        {
            //check if all 4 pegs are hammered in to be completed
            if (firstPegCollected && secondPegCollected && thirdPegCollected && fourthPegCollected)
            {
                

                //set hammering of pegs as complete
                completedPegs = true;
                
                // Hide list UI
                listUI.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        //The GameObject that this GameManager class is attached to will now not be destroyed when scenes are changed.
        DontDestroyOnLoad(gameObject);
    }

    public void firstPegCollect()
    {
        // Set that firstPeg is collected
        firstPegCollected = true;

        // Strikethrough firstPeg UI
        firstPegUI.fontStyle = FontStyles.Strikethrough;
    }

    public void secondPegCollect()
    {
        // Set that secondPeg is collected
        secondPegCollected = true;

        // Strikethrough secondPegUI
        secondPegUI.fontStyle = FontStyles.Strikethrough;

    }

    public void thirdPegCollect()
    {
        // Set that thirdPeg is collected
        thirdPegCollected = true;

        //Strikethrough thirdPeg UI
        thirdPegUI.fontStyle = FontStyles.Strikethrough;
    }

    public void fourthPegCollect()
    {
        // Set that egg is collected
        fourthPegCollected = true;

        // Strikethrough fourthPeg UI
        fourthPegUI.fontStyle = FontStyles.Strikethrough;
    }


}
