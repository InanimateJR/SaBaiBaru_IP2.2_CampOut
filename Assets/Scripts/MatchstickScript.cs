using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchstickScript : MonoBehaviour
{
    public void AddGravity()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
