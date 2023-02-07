using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySocketScript : MonoBehaviour
{
    public GameObject[] inventoryArray;
    int i;
    public void ObjectSnapped()
    {
        inventoryArray[i].GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        inventoryArray[i] = other.gameObject;
        i++;
    }
}
