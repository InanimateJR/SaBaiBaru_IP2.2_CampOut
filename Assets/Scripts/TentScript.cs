using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TentScript : MonoBehaviour
{
    public GameObject smokePoof;
    public GameObject tentGroup;
    public GameObject foldedTent;
    private XRGrabInteractable foldedTentInteractable;
    private Rigidbody foldedTentRigidbody;

    private void Start()
    {
        foldedTentInteractable = foldedTent.GetComponent<XRGrabInteractable>();
        foldedTentRigidbody = foldedTent.GetComponent<Rigidbody>();
    }

    public void StartTentPitching()
    {
        StartCoroutine("PitchTent");
    }

    IEnumerator PitchTent()
    {
        Destroy(foldedTentRigidbody);
        Destroy(foldedTentInteractable);
        yield return new WaitForSeconds(1.5f);
        smokePoof.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        tentGroup.SetActive(true);
        foldedTent.SetActive(false);
    }
}
