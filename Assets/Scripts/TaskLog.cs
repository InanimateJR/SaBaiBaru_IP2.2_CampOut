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

    // Assign object "Task 1" in Notepad
    public TextMeshProUGUI task1Text;

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
    public TextMeshProUGUI fishOnSticksToCookUI;

    // Assign 6 object "Mushroom" in sticks 
    public TextMeshProUGUI stickEdibleMushroomsUI;

    // Assign 6 object "Mushrooms" in sticks to the fireplace socket
    public TextMeshProUGUI mushroomsOnSticksToCookUI;

    

    //  Assign Inventory UI
    public GameObject listUI;

    //Assign 3 object "Mushroom"
    public TextMeshProUGUI mushroomCollectUI;

    //Assign to trading function for fishing rod
    public TextMeshProUGUI mushroomTradeUI;

    // Assign object "Task 3" in Notepad
    public TextMeshProUGUI task3Text;

    // Assign object "Task 5" in Notepad
    public TextMeshProUGUI task5Text;

    // Assign object "Task 6" in Notepad
    public TextMeshProUGUI task6Text;

    // Assign object "Task 7" in Notepad
    public TextMeshProUGUI task7Text;

    // Assign object "Task 8" in Notepad
    public TextMeshProUGUI task8Text;

    // Assign object "Task 9" in Notepad
    public TextMeshProUGUI task9Text;

    //Assign 4 objects "Leaves" 
    public TextMeshProUGUI leavesPilesUI;

    //Assign 7 objects "Sticks"
    public TextMeshProUGUI sticksCollectedUI;

    //Assign to trading function for firewood
    public TextMeshProUGUI fishTradeUI;

    //Assign to function when campfire is finished
    public TextMeshProUGUI campfireBuiltUI;


    /// Boolean values

    // Check if Task 1 is Complete
    public bool task1Complete;

    // Check if Task 2 is complete
    public bool task2Complete;

    // Check if Task 3 is complete
    public bool task3Complete;

    // Check if Task 4 is complete
    public bool task4Complete;

    // Check if Task 5 is complete
    public bool task5Complete;

    // Check if Task 6 is complete
    public bool task6Complete;

    // Check if Task 7 is complete
    public bool task7Complete;

    // Check if Task 8 is complete
    public bool task8Complete;

    // Check if Task 9 is complete
    public bool task9Complete;

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
    public bool allFishOnSticks = false;

    // All 6 mushrooms are on a stick 
    public bool allEdibleMushroomOnSticks = false;

    public bool edibleMushroomToCook = false;

    public bool fishToCook = false;

    //All 3 mushrooms needed for trade
    public bool allMushroomsCollected = false;

    //check for mushroom trade
    public bool mushroomsTraded = false;

    //check for 8 sticks
    public bool allSticksCollected = false;
    //check for 4 leaf piles
    public bool allLeavesCollected = false;
    //check for 6 logs
    public bool allLogsCollected = false;
    //check for campfire built
    public bool campfireAssembled = false;

    // integer values to count

    //to count mushrooms collected
    public int mushroomsCollected;

    //to count sticks collected
    public int sticksCollected;

    //to count leaves collected
    public int leavesCollected;

    //to count logs collected
    public int logsCollected;

    //to count fish on sticks
    public int fishOnSticks = 0;

    //to count mushroom on sticks
    public int edibleMushroomOnSticks = 0;

    //to count fish near fire
    public int fishNearFire = 0;

    //to count mushroom near fire
    public int edibleMushroomNearFire = 0;


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
        //strikeout task 2 on notepad
        if (completedPegs && tentSpotConfirmed && !task2Complete)
        {
            task2Complete = true;
            task2Text.fontStyle = FontStyles.Strikethrough;
        }

        //strikeout task 4 on notepad
        if (!task4Complete && fishingScript.fishesCaught >= 3)
        {
            task4Complete = true;
            task4Text.fontStyle = FontStyles.Strikethrough;
        }

        //strikeout task 3 on notepad
        if (mushroomsTraded && allMushroomsCollected && !task3Complete)
        {
            task3Complete = true;
            task3Text.fontStyle = FontStyles.Strikethrough;
        }

        //strikeout task 5 on notepad
        if (allLeavesCollected && allLogsCollected && !task5Complete)
        {
            task5Complete = true;
            task5Text.fontStyle = FontStyles.Strikethrough;
        } 

        if(allFishOnSticks && fishToCook && !task7Complete)
        {
            task7Complete = true;
            Task7Done();
        }

        if(allEdibleMushroomOnSticks && edibleMushroomToCook && !task8Complete)
        {
            task8Complete = true;
            Task8Done();
        }


        if (fishOnSticks >= 3 && !allFishOnSticks)
        {
            allFishOnSticks = true;
            FishesOnSticksDone();

        }

        //if 3 mushrooms are on sticks, strikethrough task
        if (edibleMushroomOnSticks >= 6 && !allEdibleMushroomOnSticks)
        {
            allEdibleMushroomOnSticks = true;
            MushroomsOnSticksDone();
        }

        //if 3 fishes on sticks are on fire, strikethrough task
        if (fishNearFire > 3)
        {
            FishesOnSticksToGroundDone();
        }
        //if 6 muushrooms on sticks are on fire, strikethrough task
        if (edibleMushroomNearFire > 6)
        {
            MushroomsOnSticksToGroundDone();
        }

    }

    public void VisitedCabin()
    {
        task1Complete = true;
        task1Text.fontStyle = FontStyles.Strikethrough;
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

    public void MushroomCollected()
    {
        //add 1 to mushroom counter, if its 3, strike out subtask 3.1
        mushroomsCollected++;
        if (mushroomsCollected == 3 && !allMushroomsCollected)
        {
            mushroomCollectUI.fontStyle = FontStyles.Strikethrough;
            allMushroomsCollected = true;
        }
    }

    public void FishermanTradeCompleted()
    {
        //upon picking up fishing rod, strike out subtask 3.2
        if (!mushroomsTraded)
        {
            mushroomsTraded = true;
            mushroomTradeUI.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void SticksCollection()
    {
        sticksCollected++;
        if (sticksCollected == 8)
        {
            sticksCollectedUI.fontStyle = FontStyles.Strikethrough;
            allSticksCollected = true;
        }
    }

    public void LeafCollection()
    {
        leavesCollected++;
        if (leavesCollected == 4)
        {
            allLeavesCollected = true;
            leavesPilesUI.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void LogsCollection()
    {
        logsCollected++;
        if (logsCollected == 4)
        {
            allLogsCollected = true;
            leavesPilesUI.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void CampFireAssembled()
    {
        campfireBuiltUI.fontStyle = FontStyles.Strikethrough;
        campfireAssembled = true;
    }

    public void Task7Done()
    {

        task7Text.fontStyle = FontStyles.Strikethrough;
}

    public void Task8Done()
    {
        task8Text.fontStyle = FontStyles.Strikethrough;
    }

    public void FishesOnSticksDone()
    {
        allFishOnSticks = true;
        stickFishesUI.fontStyle = FontStyles.Strikethrough;
    }

    public void MushroomsOnSticksDone()
    {
        allEdibleMushroomOnSticks = true;
        stickEdibleMushroomsUI.fontStyle = FontStyles.Strikethrough;
    }

    public void FishesOnSticksToGroundDone()
    {
        fishToCook = true;
        fishOnSticksToCookUI.fontStyle = FontStyles.Strikethrough;
    }

    public void MushroomsOnSticksToGroundDone()
    {
        edibleMushroomToCook = true;
        mushroomsOnSticksToCookUI.fontStyle = FontStyles.Strikethrough;
    }

    public void EatenFood()
    {
        task9Complete = true;
        task9Text.fontStyle = FontStyles.Strikethrough;
        Debug.Log("Task 9 has been completed");
    }

    public void LightCampfire()
    {
        if (!task6Complete)
        {
            task6Complete = true;
            task6Text.fontStyle = FontStyles.Strikethrough;
        }

    }
}
