using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotScript : MonoBehaviour
{
    public GameObject[] inventoryArray;         // Array storing snapped objects
    public GameObject[] inventorySocketArray;   // Array storing sockets
    public int i;

    public InventorySocketScript inventorySocketScript;

    public void ObjectSnapped()
    {
        inventorySocketScript = inventorySocketArray[i].GetComponent<InventorySocketScript>();
        inventorySocketScript.objectSnapped = true;
        //inventoryArray[i].SetActive(false);
        if (i > 1)
        {
            inventorySocketArray[i - 1].SetActive(false);
            inventoryArray[i - 1].SetActive(false);
        }
        inventorySocketArray[i+1].SetActive(true);
        i++;
    }

    public void ObjectRemoved()
    {
        if (i > 0)
        {
            i--;
        }
        inventorySocketScript.objectSnapped = false;
    }
}
