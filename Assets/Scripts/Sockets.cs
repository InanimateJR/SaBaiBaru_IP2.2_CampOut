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
            Invoke("DisableSocket", 1);
        }
        

        //IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
    }
    public void DisableSocket()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        Destroy(myGrabbable);
        Destroy(myRigidbody);
    }
}