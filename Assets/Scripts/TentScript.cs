using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TentScript : MonoBehaviour
{
    public GameObject smokePoof;

    public GameObject tentGroup1;
    public GameObject tentGroup2;
    public GameObject tentGroup3;

    public GameObject foldedTent;
    private XRGrabInteractable foldedTentInteractable;
    private Rigidbody foldedTentRigidbody;
    public GameObject orangeFlag1;
    public GameObject orangeFlag2;
    public GameObject orangeFlag3;
    public XRSocketInteractor foldedTentSocket;

    public bool snappedSocket1;
    public bool snappedSocket2;
    public bool snappedSocket3;

    private void Start()
    {
        foldedTentInteractable = foldedTent.GetComponent<XRGrabInteractable>();
        foldedTentRigidbody = foldedTent.GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    public void StartTentPitching()
    {
        StartCoroutine("PitchTent");
    }

    IEnumerator PitchTent()
    {
        foldedTentSocket.allowHover = false;
        foldedTentSocket.allowSelect = false;
        Destroy(orangeFlag1);
        Destroy(orangeFlag2);
        Destroy(orangeFlag3);
        Destroy(foldedTentRigidbody);
        Destroy(foldedTentInteractable);
        yield return new WaitForSeconds(1.5f);
        smokePoof.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        if (snappedSocket1)
        {
            tentGroup1.SetActive(true);
        }
        else if (snappedSocket2)
        {
            tentGroup2.SetActive(true);
        }
        else if (snappedSocket3)
        {
            tentGroup3.SetActive(true);
        }

        foldedTent.SetActive(false);
    }
}
