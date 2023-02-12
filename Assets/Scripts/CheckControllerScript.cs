using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckControllerScript : MonoBehaviour
{
    public TeleportRayController teleportRayController;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two) && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f)
        {
            Debug.Log("RightOn");
            teleportRayController.rightControllerGrab = true;
        }

        else if (!OVRInput.Get(OVRInput.Button.Two) && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.1f)
        {
            Debug.Log("RightOff");
            teleportRayController.rightControllerGrab = false;
        }

        if (OVRInput.Get(OVRInput.Button.Four) && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f)
        {
            Debug.Log("LeftOn");
            teleportRayController.leftControllerGrab = true;
        }

        else if (!OVRInput.Get(OVRInput.Button.Four) && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.1f)
        {
            Debug.Log("LeftOff");
            teleportRayController.leftControllerGrab = false;
        }
    }
}
