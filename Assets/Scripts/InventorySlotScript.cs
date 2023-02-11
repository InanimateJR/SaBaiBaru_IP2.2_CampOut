using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour
{
    public GameObject[] inventorySocketArray;   // Array storing sockets
    public int snappedObjects;
    public bool objectSnapped;
    public bool slotOccupied;

    public GameObject tentGroup;
    public GameObject matchboxGroup;
    public GameObject cookedFishGroup;
    public GameObject stickGroup;
    public GameObject firewoodGroup;
    public GameObject leavesGroup;
    public GameObject mushroomsEdibleGroup;
    public GameObject mushroomsEdibleCookedGroup;
    public GameObject mushroomsPoisonousGroup;
    public GameObject mushroomsPoisonousCookedGroup;

    public GameObject snappedObject;

    public Image hoverImage;
    public Color hoverColour;
    public Color defaultColour;

    public void ObjectRemoved()
    {
        objectSnapped = false;
        cookedFishGroup.SetActive(true);
        tentGroup.SetActive(true);
        matchboxGroup.SetActive(true);
        stickGroup.SetActive(true);
        firewoodGroup.SetActive(true);
        leavesGroup.SetActive(true);
        mushroomsEdibleCookedGroup.SetActive(true);
        mushroomsEdibleGroup.SetActive(true);
        mushroomsPoisonousCookedGroup.SetActive(true);
        mushroomsPoisonousGroup.SetActive(true);
    }

    public void SnappedCookedFish()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        stickGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        leavesGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedTent()
    {
        objectSnapped = true;
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        stickGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        leavesGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedMatchbox()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        stickGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        leavesGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedStick()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        leavesGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedFirewood()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        stickGroup.SetActive(false);
        leavesGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedLeaves()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        stickGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedMushroomEdibleCooked()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        stickGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedMushroomEdible()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        stickGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedMushroomPoisonousCooked()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        stickGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousGroup.SetActive(false);
    }

    public void SnappedMushroomPoisonous()
    {
        objectSnapped = true;
        tentGroup.SetActive(false);
        cookedFishGroup.SetActive(false);
        matchboxGroup.SetActive(false);
        firewoodGroup.SetActive(false);
        stickGroup.SetActive(false);
        mushroomsEdibleCookedGroup.SetActive(false);
        mushroomsEdibleGroup.SetActive(false);
        mushroomsPoisonousCookedGroup.SetActive(false);
    }
}

