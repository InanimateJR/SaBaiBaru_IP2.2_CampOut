using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchstickScript : MonoBehaviour
{
    public GameObject fireVFX;

    public void AddGravity()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void IgniteMatch()
    {
        if (fireVFX != null)
        {
            fireVFX.SetActive(true);
            StartCoroutine("DestroyMatch");
        }
    }

    IEnumerator DestroyMatch()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
        yield return null;
    }
}
