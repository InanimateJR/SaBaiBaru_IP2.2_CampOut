using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Sockets : MonoBehaviour
{
    public void SocketCheck()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        if (myGrabbable.firstInteractorSelecting is XRSocketInteractor)
        {
            if (myGrabbable.firstInteractorSelecting.transform.tag == "CampfireSocket")
            {
                Invoke("DisableSocket", 0.5f);

            }
        }
    }
    public void DisableSocket()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        Destroy(myGrabbable);
        Destroy(myRigidbody);
    }
}