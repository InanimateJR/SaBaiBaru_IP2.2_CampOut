using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinTrigger : MonoBehaviour
{
    public TaskLog taskLogScript;

    private void OnTriggerEnter(Collider other)
    {
        taskLogScript.VisitedCabin();
    }
}
