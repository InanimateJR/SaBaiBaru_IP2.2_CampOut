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
        hoverImage.color = defaultColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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
        hoverImage.color = hoverColour;
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

