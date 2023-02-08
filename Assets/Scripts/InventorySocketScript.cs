using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySocketScript : MonoBehaviour
{
    public InventorySlotScript inventorySlotScript;

    public LeafScript leafScript;

    public bool objectSnapped;

    private void OnTriggerEnter(Collider other)
    {
        if (objectSnapped && other.gameObject.transform.root.tag == "Leafpile")
        {
            Debug.Log("Trigger entered");
            if (inventorySlotScript.i != 0)
            {
                inventorySlotScript.inventoryArray[inventorySlotScript.i - 1] = other.gameObject.transform.root.gameObject;
            }
            leafScript = other.gameObject.transform.root.gameObject.GetComponent<LeafScript>();
            Debug.Log("LeafScript: " + leafScript);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (objectSnapped && other.gameObject.transform.root.tag == "Leafpile")
        {
            if (inventorySlotScript.i != 0)
            {
                inventorySlotScript.inventoryArray[inventorySlotScript.i - 1] = other.gameObject.transform.root.gameObject;
            }
            leafScript = other.gameObject.transform.root.gameObject.GetComponent<LeafScript>();

            if (objectSnapped)
            {
                leafScript.TurnOffRenderers();
                objectSnapped = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectSnapped && other.gameObject.transform.root.tag == "Leafpile")
        {
            Debug.Log("Trigger exited");

            if (inventorySlotScript.i > 0)
            {
                inventorySlotScript.inventorySocketArray[inventorySlotScript.i].SetActive(true);
                //inventorySlotScript.inventoryArray[inventorySlotScript.i].SetActive(true);
            }

            if (!objectSnapped)
            {
                leafScript.TurnOnRenderers();
            }

            inventorySlotScript.inventoryArray[inventorySlotScript.i + 1] = null;
        }
    }
}
