using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cooked Edible Mushroom")
        {
            
            Destroy(other.gameObject);
            Debug.Log("Food as been eaten");
        }
        else if (other.gameObject.tag == "Cooked Fish")
        {

            Destroy(other.gameObject);
            Debug.Log("Poison as been eaten");
        }
        else if (other.gameObject.tag == "Cooked Poison Mushroom")
        {

            Destroy(other.gameObject);
            Debug.Log("Poison as been eaten");
        }
    }
}
