using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafScript : MonoBehaviour
{
    public bool snapped;
    public bool collected;

    public MeshRenderer[] leafRenderers;

    public Image hoverImage;
    public Color hoverColour;
    public Color defaultColour;

    public InventorySlotScript inventorySlotScript;

    private void Update()
    {
        if (inventorySlotScript != null)
        {
            if (inventorySlotScript.objectSnapped)
            {
                snapped = true;
                Debug.Log("Renderer off");
                for (int i = 0; i < leafRenderers.Length; i++)
                {
                    leafRenderers[i].enabled = false;
                }
            }

            if (!inventorySlotScript.objectSnapped)
            {
                snapped = false;
                for (int i = 0; i < leafRenderers.Length; i++)
                {
                    leafRenderers[i].enabled = true;
                }
            }
        }

        if (!collected)
        {
            collected = true;
            // DDA ADD DATA HERE
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeafpileSocket")
        {
            hoverImage.color = hoverColour;
            inventorySlotScript = other.gameObject.GetComponent<InventorySlotScript>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LeafpileSocket")
        {
            if (!snapped)
            {
                hoverImage.color = hoverColour;
            }

            else if (snapped)
            {
                hoverImage.color = defaultColour;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LeafpileSocket")
        {
            hoverImage.color = defaultColour;
        }
    }
}
