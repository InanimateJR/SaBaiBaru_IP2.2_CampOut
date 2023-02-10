using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Leafpile")
        {
            other.gameObject.transform.localScale = new Vector3(0.16915f, 0.2363533f, 0.16915f);
        }

        if (other.gameObject.tag == "Tent")
        {
            other.gameObject.transform.localScale = new Vector3(0.1163466f, 0.1163466f, 0.1163466f); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Leafpile")
        {
            other.gameObject.transform.localScale = new Vector3(1, 1.3973f, 1);
        }

        if (other.gameObject.tag == "Tent")
        {
            other.gameObject.transform.localScale = new Vector3(0.63265f, 0.63265f, 0.63265f);
        }
    }
}
