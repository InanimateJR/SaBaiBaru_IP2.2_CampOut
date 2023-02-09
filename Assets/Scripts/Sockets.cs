using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Sockets : MonoBehaviour
{
    public void SocketCheck()
    {
        Invoke("DisableSocket", 1);

        //IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
    }
    void DisableSocket()
    {
        XRGrabInteractable myGrabbable = GetComponent<XRGrabInteractable>();
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        if (myGrabbable.firstInteractorSelecting is XRSocketInteractor)
        {
            Destroy(myGrabbable);
            Destroy(myRigidbody);
        }
    }
}