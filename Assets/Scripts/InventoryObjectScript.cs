using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectScript : MonoBehaviour
{
    public bool snapped;
    public bool collected;

    private MeshRenderer objectRenderer;

    public GameObject inventorySlot;
    public InventorySlotScript inventorySlotScript;

    public MeshRenderer[] matchboxArray;
    public GameObject[] otherObjectsArray;
    private Rigidbody objectRigidbody;

    private void Start()
    {
        objectRenderer = this.gameObject.GetComponent<MeshRenderer>();
        objectRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (inventorySlotScript != null)
        {
            if (inventorySlotScript.objectSnapped && !inventorySlotScript.slotOccupied && objectRigidbody != null)
            {
                snapped = true;
                inventorySlotScript.slotOccupied = true;
                objectRenderer.enabled = false;
                objectRigidbody.useGravity = false;
                if (this.gameObject.name == "Matchbox Final")
                {
                    TurnOffOtherObjects();
                }

                if (!collected)
                {
                    collected = true;
                }
            }

            if (!inventorySlotScript.objectSnapped && inventorySlotScript.slotOccupied && objectRigidbody != null)
            {
                snapped = false;
                inventorySlotScript.slotOccupied = false;
                objectRenderer.enabled = true;
                objectRigidbody.useGravity = true;
                if (this.gameObject.name == "Matchbox Final")
                {
                    TurnOnOtherObjects();
                }
            }
        }

        if (inventorySlotScript == null && objectRigidbody != null)
        {
            objectRenderer.enabled = true;
            objectRigidbody.useGravity = true;
            if (this.gameObject.name == "Matchbox Final")
            {
                TurnOnOtherObjects();
            }
        }
    }

    public void TurnOffOtherObjects()
    {
        for (int i = 0; i < matchboxArray.Length; i++)
        {
            if (matchboxArray[i] != null)
            {
                matchboxArray[i].enabled = false;
            }
        }
        for (int i = 0; i < otherObjectsArray.Length; i++)
        {
            if (otherObjectsArray[i] != null)
            {
                otherObjectsArray[i].SetActive(false);
            }
        }
    }

    public void TurnOnOtherObjects()
    {
        for (int i = 0; i < matchboxArray.Length; i++)
        {
            if (matchboxArray[i] != null)
            {
                matchboxArray[i].enabled = true;
            }
        }
        for (int i = 0; i < otherObjectsArray.Length; i++)
        {
            if (otherObjectsArray[i] != null)
            {
                otherObjectsArray[i].SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InventorySlot")
        {
            inventorySlot = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "InventorySlot")
        {
            if (inventorySlotScript == null && inventorySlot != null)
            {
                inventorySlotScript = inventorySlot.GetComponent<InventorySlotScript>();

                if (inventorySlot.gameObject != inventorySlotScript.gameObject)
                {
                    inventorySlotScript = null;
                }
            }

            if (inventorySlotScript != null)
            {
                if (inventorySlotScript.snappedObject == null)
                {
                    inventorySlotScript.snappedObject = this.gameObject;
                }

/*                if (inventorySlotScript.hoverImage.color == inventorySlotScript.defaultColour)
                {
                    inventorySlotScript.hoverImage.color = inventorySlotScript.hoverColour;
                }*/
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (inventorySlotScript != null)
        {
            if (other.gameObject.tag == "InventorySlot" && !inventorySlotScript.objectSnapped && inventorySlot != null)
            {
                inventorySlotScript.snappedObject = null;
                inventorySlotScript = null;
                inventorySlot = null;
                //inventorySlotScript.hoverImage.color = inventorySlotScript.defaultColour;
            }
        }
    }
}
