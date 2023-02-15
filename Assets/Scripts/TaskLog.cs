using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskLog : MonoBehaviour
{
    /// Defining Values
    
    // Store number of pegs hammered
    public int pegsHammered;

    /// Creating TMP text objects

    // Assign object "Task 2" in Notepad
    public TextMeshProUGUI task2Text;

    // Assign object "Task 4" in Notepad
    public TextMeshProUGUI task4Text;

    // Assign object "Tent Instruction Text" in Notepad
    public TextMeshProUGUI completedPegsText;

    // Assign object "TentPlaced" in Notepad
    public TextMeshProUGUI tentPlaced;

    // Assign object "firstPeg" in Notepad
    public TextMeshProUGUI firstPegUI;

    // Assign object "secondPeg" in Notepad
    public TextMeshProUGUI secondPegUI;

    // Assign object "thirdPeg" in Notepad
    public TextMeshProUGUI thirdPegUI;

    // Assign object "fourthPeg" in Notepad
    public TextMeshProUGUI fourthPegUI;

    // Assign 3 object "RawFish" in sticks 
    public TextMeshProUGUI stickFishesUI;

    // Assign 3 object "RawFish" in sticks to the fireplace socket
    public TextMeshProUGUI fishOnSticksUI;

    // Assign 6 object "Mushroom" in sticks 
    public TextMeshProUGUI stickMushroomsUI;

    // Assign 6 object "Mushrooms" in sticks to the fireplace socket
    public TextMeshProUGUI mushroomsOnSticksUI;

    //  Assign Inventory UI
    public GameObject listUI;

    /// Boolean values

    // Check if Task 2 is complete
    public bool task2Complete;

    // Check if Task 4 is complete
    public bool task4Complete;

    // Whether Tent Spot has been confirmed
    public bool tentSpotConfirmed = false;

    // Whether firstPeg is collected or not
    public bool firstPegHammered = false;

    // Whether secondPeg is collected or not
    public bool secondPegHammered = false;

    // Whether thirdPeg is collected or not
    public bool thirdPegHammered = false;

    // Whether fourthPeg is collected or not
    public bool fourthPegHammered = false;

    // All 4 pegs are not hammered in 
    private bool completedPegs = false;

    // All 3 fishes are on a stick 
    public bool allfishOnSticks = false;

    // All 6 mushrooms are on a stick 
    public bool allMushroomshOnSticks = false;


    /// SCRIPT REFERENCES

    public FishingScript fishingScript;


    void Start()
    {
        // Number of items collected starts at 0
        pegsHammered = 0;
    }

    void Update()
    {
        //if hammering not commplete
        if (!completedPegs)
        {
            //check if all 4 pegs are hammered in to be completed
            if (firstPegHammered && secondPegHammered && thirdPegHammered && fourthPegHammered)
            {
                //set hammering of pegs as complete
                completedPegs = true;

                completedPegsText.fontStyle = FontStyles.Strikethrough;

                // Hide list UI
                listUI.SetActive(true);
            }
        }

        if (completedPegs && tentSpotConfirmed && !task2Complete)
        {
            task2Complete = true;
            task2Text.fontStyle = FontStyles.Strikethrough;
        }

        if (!task4Complete && fishingScript.fishesCaught >= 3)
        {
            task4Complete = true;
            task4Text.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void TentSpotConfirmed()
    {
        tentSpotConfirmed = true;

        tentPlaced.fontStyle = FontStyles.Strikethrough;
    }

    public void FirstPegHammered()
    {
        // Set that firstPeg is hammered
        firstPegHammered = true;

        // Strikethrough firstPeg UI
        firstPegUI.fontStyle = FontStyles.Strikethrough;

        pegsHammered++;
    }

    public void SecondPegHammered()
    {
        // Set that secondPeg is hammered
        secondPegHammered = true;

        // Strikethrough secondPegUI
        secondPegUI.fontStyle = FontStyles.Strikethrough;

        pegsHammered++;
    }

    public void ThirdPegHammered()
    {
        // Set that thirdPeg is hammered
        thirdPegHammered = true;

        //Strikethrough thirdPeg UI
        thirdPegUI.fontStyle = FontStyles.Strikethrough;

        pegsHammered++;
    }

    public void FourthPegHammered()
    {
        // Set that fourthPeg is hammered
        fourthPegHammered = true;

        // Strikethrough fourthPeg UI
        fourthPegUI.fontStyle = FontStyles.Strikethrough;

        pegsHammered++;
    }
}
