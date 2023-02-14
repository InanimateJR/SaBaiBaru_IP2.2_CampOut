using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskLog : MonoBehaviour
{
    /// Defining Values
    
    // Store number of pegs collected
    public int pegsCollected;

    /// Creating TMP text objects
    // Assign object "firstPeg" in inventory
    public TMP_Text firstPegUI;

    // Assign object "secondPeg" in inventory
    public TMP_Text secondPegUI;

    // Assign object "thirdPeg" in inventory
    public TMP_Text thirdPegUI;

    // Assign object "fourthPeg" in inventory 
    public TMP_Text fourthPegUI;

    // Assign 3 object "RawFish" in sticks 
    public TMP_Text stickFishesUI;

    // Assign 3 object "RawFish" in sticks to the fireplace socket
    public TMP_Text fishOnSticksUI;

    // Assign 6 object "Mushroom" in sticks 
    public TMP_Text stickMushroomsUI;

    // Assign 6 object "Mushrooms" in sticks to the fireplace socket
    public TMP_Text mushroomsOnSticksUI;

    //  Assign Inventory UI
    public GameObject listUI;

    /// Boolean values
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

    // All 3 fishes are on a stick 
    public bool allfishOnSticks = false;

    // All 6 mushrooms are on a stick 
    public bool allMushroomshOnSticks = false;



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
