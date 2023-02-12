using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportRayScript : MonoBehaviour
{
    public bool rightControllerGrip;
    public bool rightControllerButton2;
    public bool leftControllerGrip;
    public bool leftControllerButton2;

    public XRRayInteractor leftRayInteractor;
    public XRRayInteractor rightRayInteractor;

    public GameObject leftTeleportReticle;
    public GameObject rightTeleportReticle;

    bool leftRayInteractorOn;
    bool rightRayInteractorOn;

    // Update is called once per frame
    void Update()
    {
        if (leftControllerButton2 && leftControllerGrip && !leftRayInteractorOn)
        {
            leftRayInteractor.enabled = true;
            leftRayInteractorOn = true;
            leftTeleportReticle.SetActive(true);
        }

        else if (!leftControllerButton2 && !leftControllerGrip && leftRayInteractorOn)
        {
            leftRayInteractor.enabled = false;
            leftRayInteractorOn = false;
            leftTeleportReticle.SetActive(false);
        }

        if (rightControllerButton2 && rightControllerGrip && !rightRayInteractorOn)
        {
            rightRayInteractor.enabled = true;
            rightRayInteractorOn = true;
            rightTeleportReticle.SetActive(true);
        }

        else if (!rightControllerButton2 && !rightControllerGrip && rightRayInteractorOn)
        {
            rightRayInteractor.enabled = false;
            rightRayInteractorOn = false;
            rightTeleportReticle.SetActive(false);
        }
    }
}
