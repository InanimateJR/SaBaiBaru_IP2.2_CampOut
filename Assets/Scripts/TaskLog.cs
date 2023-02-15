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
                
                // Hide list UI
                listUI.SetActive(true);
            }
        }
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
