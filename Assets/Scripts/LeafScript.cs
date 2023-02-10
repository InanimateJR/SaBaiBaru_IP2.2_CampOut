using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafScript : MonoBehaviour
{
    public bool snapped;
    public bool collected;

    public MeshRenderer[] leafRenderers;

    public GameObject inventorySlot;
    public InventorySlotScript inventorySlotScript;
    private Rigidbody leafRigidbody;

    private void Start()
    {
        leafRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (inventorySlotScript != null)
        {
            if (inventorySlotScript.objectSnapped && !inventorySlotScript.slotOccupied)
            {
                snapped = true;
                inventorySlotScript.slotOccupied = true;
                leafRigidbody.useGravity = false;
                Debug.Log("Renderer off");
                TurnOffMeshRenderers();
                if (!collected)
                {
                    collected = true;
                    // DDA ADD DATA HERE
                }
            }

            if (!inventorySlotScript.objectSnapped && inventorySlotScript.slotOccupied)
            {
                snapped = false;
                inventorySlotScript.slotOccupied = false;
                leafRigidbody.useGravity = true;
                TurnOnMeshRenderers();
            }

            if (inventorySlotScript.snappedObject == null)
            {
                inventorySlot = null;
                inventorySlotScript = null;
            }
        }

        if (inventorySlotScript == null)
        {
            leafRigidbody.useGravity = true;
            TurnOnMeshRenderers();
        }
    }

    public void TurnOffMeshRenderers()
    {
        for (int i = 0; i < leafRenderers.Length; i++)
        {
            leafRenderers[i].enabled = false;
        }
    }

    public void TurnOnMeshRenderers()
    {
        for (int i = 0; i < leafRenderers.Length; i++)
        {
            leafRenderers[i].enabled = true;
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
            inventorySlotScript.snappedObject = null;
            inventorySlotScript.hoverImage.color = inventorySlotScript.defaultColour;
        }
    }
}
