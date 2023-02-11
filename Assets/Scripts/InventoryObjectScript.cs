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
            if (inventorySlotScript.objectSnapped && !inventorySlotScript.slotOccupied)
            {
                snapped = true;
                inventorySlotScript.slotOccupied = true;
                Debug.Log("Renderer off");
                objectRenderer.enabled = false;
                objectRigidbody.useGravity = false;
                if (this.gameObject.name == "Matchbox Ready")
                {
                    TurnOffOtherObjects();
                }

                if (!collected)
                {
                    collected = true;
                }
            }

            if (!inventorySlotScript.objectSnapped && inventorySlotScript.slotOccupied)
            {
                Debug.Log("Renderer On");
                snapped = false;
                inventorySlotScript.slotOccupied = false;
                objectRenderer.enabled = true;
                objectRigidbody.useGravity = true;
                if (this.gameObject.name == "Matchbox Ready")
                {
                    TurnOnOtherObjects();
                }
            }
        }

        if (inventorySlotScript == null)
        {
            Debug.Log("InventorySlotScript null");
            objectRenderer.enabled = true;
            objectRigidbody.useGravity = true;
            if (this.gameObject.name == "Matchbox Ready")
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
            if (inventorySlotScript == null)
            {
                inventorySlotScript = inventorySlot.GetComponent<InventorySlotScript>();
            }

            if (inventorySlotScript != null)
            {
                if (inventorySlotScript.snappedObject == null)
                {
                    inventorySlotScript.snappedObject = this.gameObject;
                }

                if (inventorySlotScript.hoverImage.color == inventorySlotScript.defaultColour)
                {
                    inventorySlotScript.hoverImage.color = inventorySlotScript.hoverColour;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InventorySlot")
        {
            Debug.Log("Exit");
            inventorySlotScript.snappedObject = null;
            inventorySlotScript.hoverImage.color = inventorySlotScript.defaultColour;
        }
    }
}
