using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    public InventoryObjectScript inventoryObjectScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Leafpile")
        {
            inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
            other.gameObject.transform.localScale = new Vector3(0.16915f, 0.16915f, 0.16915f);
        }

        if (other.gameObject.tag == "Tent")
        {
            inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
            other.gameObject.transform.localScale = new Vector3(0.1163466f, 0.1163466f, 0.1163466f);
        }

        if (other.gameObject.tag == "Stick")
        {
            inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
            other.gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }

        if (other.gameObject.tag == "Cooked Fish")
        {
            inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
            other.gameObject.transform.localScale = new Vector3(0.1292207f, 0.1292207f, 0.1292207f);
        }

        if (other.gameObject.tag == "Mushroom" || other.gameObject.tag == "Poison Mushroom" || other.gameObject.tag == "Cooked Poison Mushroom" || other.gameObject.tag == "Cooked Edible Mushroom")
        {
            inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
            other.gameObject.transform.localScale = new Vector3(2.966417f, 2.966417f, 2.966417f);
        }

        if (other.gameObject.tag == "Log")
        {
            inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
            other.gameObject.transform.localScale = new Vector3(0.5499497f, 3.700222f, 0.5499497f);
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (inventoryObjectScript != null)
        {
            if (inventoryObjectScript.snapped)
            {
                if (other.gameObject.tag == "Leafpile")
                {
                    inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
                    other.gameObject.transform.localScale = new Vector3(0.16915f, 0.16915f, 0.16915f);
                }

                if (other.gameObject.tag == "Tent")
                {
                    inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
                    other.gameObject.transform.localScale = new Vector3(0.1163466f, 0.1163466f, 0.1163466f);
                }

                if (other.gameObject.tag == "Stick")
                {
                    inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
                    other.gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }

                if (other.gameObject.tag == "Cooked Fish")
                {
                    inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
                    other.gameObject.transform.localScale = new Vector3(0.1292207f, 0.1292207f, 0.1292207f);
                }

                if (other.gameObject.tag == "Mushroom" || other.gameObject.tag == "Poison Mushroom" || other.gameObject.tag == "Cooked Poison Mushroom" || other.gameObject.tag == "Cooked Edible Mushroom")
                {
                    inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
                    other.gameObject.transform.localScale = new Vector3(2.966417f, 2.966417f, 2.966417f);
                }

                if (other.gameObject.tag == "Log")
                {
                    inventoryObjectScript = other.gameObject.GetComponent<InventoryObjectScript>();
                    other.gameObject.transform.localScale = new Vector3(0.5499497f, 3.700222f, 0.5499497f);
                }
            }
        }
    }*/

    private void OnTriggerExit(Collider other)
    {  
        if (inventoryObjectScript != null)
        {
            if (!inventoryObjectScript.snapped)
            {
                if (other.gameObject.tag == "Leafpile")
                {
                    other.gameObject.transform.localScale = new Vector3(0.92045f, 0.92045f, 0.92045f);
                }

                if (other.gameObject.tag == "Tent")
                {
                    other.gameObject.transform.localScale = new Vector3(0.63265f, 0.63265f, 0.63265f);
                }

                if (other.gameObject.tag == "Stick")
                {
                    other.gameObject.transform.localScale = new Vector3(1, 1, 1);
                }

                if (other.gameObject.tag == "Cooked Fish")
                {
                    other.gameObject.transform.localScale = new Vector3(1, 1, 1);
                }

                if (other.gameObject.tag == "Mushroom" || other.gameObject.tag == "Poison Mushroom" || other.gameObject.tag == "Cooked Poison Mushroom" || other.gameObject.tag == "Cooked Edible Mushroom")
                {
                    other.gameObject.transform.localScale = new Vector3(9.061651f, 9.061651f, 9.061651f);
                }

                if (other.gameObject.tag == "Log")
                {
                    other.gameObject.transform.localScale = new Vector3(6.011203f, 40.44512f, 6.011203f);
                }
            }
        }
    }
}
