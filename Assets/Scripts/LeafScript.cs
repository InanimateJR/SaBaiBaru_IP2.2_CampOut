using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScript : MonoBehaviour
{
    public MeshRenderer[] leafRenderers;

    public void TurnOffRenderers()
    {
        for (int i = 0; i < leafRenderers.Length; i++)
        {
            leafRenderers[i].enabled = false;
        }
    }

    public void TurnOnRenderers()
    {
        for (int i = 0; i < leafRenderers.Length; i++)
        {
            leafRenderers[i].enabled = true;
        }
    }
}
