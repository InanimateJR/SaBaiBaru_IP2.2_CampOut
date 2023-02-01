using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{
    void SnappingGround()
    {
        if (gameObject.tag == "Stick")
        {
            Debug.Log("can stick");
        }
    }

}
