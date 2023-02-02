using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CookingScript : MonoBehaviour
{
    public bool foodSnapped;
    void SnappingGround()
    {
        var fire = GameObject.FindWithTag("fire");

        if (fire != null)
        {
            Debug.Log("Fire is present");
        }
    }

    void SnapFood()
    {
        foodSnapped = true;
    }

}
