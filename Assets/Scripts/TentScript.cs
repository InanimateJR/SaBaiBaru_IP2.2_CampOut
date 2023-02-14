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

    public AudioManager audioManager;

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
        yield return new WaitForSeconds(0.1f);
        foldedTentSocket.allowHover = false;
        foldedTentSocket.allowSelect = false;
        Destroy(orangeFlag1);
        Destroy(orangeFlag2);
        Destroy(orangeFlag3);
        Destroy(foldedTentRigidbody);
        Destroy(foldedTentInteractable);

        yield return new WaitForSeconds(0.5f);
        if (this.gameObject.name == "Tent Socket 1")
        {
            audioManager.TentSFX1Audio();
        }
        else if (this.gameObject.name == "Tent Socket 2")
        {
            audioManager.TentSFX2Audio();
        }
        else if (this.gameObject.name == "Tent Socket 3")
        {
            audioManager.TentSFX3Audio();
        }

        yield return new WaitForSeconds(1f);
        smokePoof.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        if (this.gameObject.name == "Tent Socket 1")
        {
            tentGroup1.SetActive(true);
        }
        else if (this.gameObject.name == "Tent Socket 2")
        {
            tentGroup2.SetActive(true);
        }
        else if (this.gameObject.name == "Tent Socket 3")
        {
            tentGroup3.SetActive(true);
        }
        foldedTent.SetActive(false);
    }
}
