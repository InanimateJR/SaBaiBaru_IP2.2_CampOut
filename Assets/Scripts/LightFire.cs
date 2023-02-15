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
        notepad = GameObject.Find("Notepad 7.0");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireVFX")
        {
            fireVFX.SetActive(true);
            notepad.GetComponent<TaskLog>().LightCampfire();
        }
    }
}
