using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireVFX")
        {
            fireVFX.SetActive(true);
        }
    }
}
