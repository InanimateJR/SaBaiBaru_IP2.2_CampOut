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
    public TMP_Text listUI;

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
                // Show list UI
                listUI.SetActive(false);

                //set hammering of pegs as complete
                completedPegs = true;
            }
        }
    }

    private void Awake()
    {
        //The GameObject that this GameManager class is attached to will now not be destroyed when scenes are changed.
        DontDestroyOnLoad(gameObject);
    }

    private void SpawnPlayerOnSceneLoad()
    {
        // if there is no player, spawn a new player at the position
        if(activePlayer == null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            activePlayer = newPlayer.GetComponent<Player>();
        }

        //Terminate execution
        else
        {
            return;
        }
    }

    public void firstPegCollected()
    {
        // Set that firstPeg is collected
        firstPegCollect = true;

        // Strikethrough firstPeg UI
        firstPegUI.fontStyle = FontStyles.Strikethrough;
    }

    public void secondPegCollected()
    {
        // Set that secondPeg is collected
        secondPegCollect = true;

        // Strikethrough secondPegUI
        secondPegUI.fontStyle = FontStyles.Strikethrough;

    }

    public void thirdPegCollected()
    {
        // Set that thirdPeg is collected
        thirdPegCollect = true;

        //Strikethrough thirdPeg UI
        thirdPegUI.fontStyle = FontStyles.Strikethrough;
    }

    public void fourthPegCollected()
    {
        // Set that egg is collected
        fourthPegCollect = true;

        // Strikethrough fourthPeg UI
        fourthPegUI.fontStyle = FontStyles.Strikethrough;
    }


}
