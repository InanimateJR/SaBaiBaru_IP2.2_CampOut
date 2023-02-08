using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotScript : MonoBehaviour
{
    public GameObject[] inventorySocketArray;   // Array storing sockets
    public int snappedObjects;
    public bool objectSnapped;

    public GameObject ghostObject;

    private void Update()
    {
        if (snappedObjects == 0)
        {
            ghostObject.SetActive(true);
        }

        else
        {
            ghostObject.SetActive(false);
        }
    }

    public void ObjectSnapped()
    {
        snappedObjects++;
        objectSnapped = true;
    }

    public void ObjectRemoved()
    {
        snappedObjects--;
        objectSnapped = false;
    }
}

