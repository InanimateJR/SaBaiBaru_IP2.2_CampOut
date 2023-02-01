using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHighlights : MonoBehaviour
{
    public void OnHover()
    {
        //Look through all the children and store their mesh renderers in the array 
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Iterate through the mesh renderer array
        foreach (MeshRenderer renderer in meshRenderers)
        {
            // for every renderer in the array, enable emission
            renderer.material.EnableKeyword("_EMISSION");
        }
    }

    public void ExitHover()
    {
        //Look through all the children and store their mesh renderers in the array 
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Iterate through the mesh renderer array
        foreach (MeshRenderer renderer in meshRenderers)
        {
            // for every renderer in the array, enable emission
            renderer.material.DisableKeyword("_EMISSION");
        }
    }
}
