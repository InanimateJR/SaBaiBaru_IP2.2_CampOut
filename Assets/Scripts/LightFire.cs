using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireVFX;
    public GameObject notepad;
    private void Start()
    {
        //calling notepad to update
        notepad = GameObject.Find("Notepad 7.0");
    }
    //when colliding with a matchstick, enable fire VFX
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireVFX")
        {
            fireVFX.SetActive(true);
            notepad.GetComponent<TaskLog>().LightCampfire();
        }
    }
}
