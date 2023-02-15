using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    // Define Materials
    public Material[] foldedTentMats;   // Material Array for Folded Tent
    public Material[] tentMats;         // Material Array for Tent
    public Material[] bagMats;          // Material Array for Bag

    // Define MeshRenderers
    public MeshRenderer foldedTentRenderer;
    public MeshRenderer[] tentRenderer;
    public MeshRenderer bagRenderer;

    // Store Player selection
    public int foldedTentSelection;
    public int tentSelection;
    public int bagSelection;

    public void SetMaterials()
    {
        foldedTentRenderer.material = foldedTentMats[foldedTentSelection];
        bagRenderer.material = bagMats[bagSelection];

        for (int i = 0; i < tentRenderer.Length; i++)
        {
            tentRenderer[i].material = tentMats[tentSelection];
        }
    }
}
