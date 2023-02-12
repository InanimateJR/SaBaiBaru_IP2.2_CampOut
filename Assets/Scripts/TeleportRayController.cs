using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class TeleportRayController : MonoBehaviour
{
    public bool rightControllerGrab;
    public bool leftControllerGrab;

    public XRRayInteractor rightRay;
    public float activationThreshold = 0.1f;

    public InputActionReference RightGrabReference = null;

    private void Awake()
    {
        RightGrabReference.action.started += AllowRightTeleport;
    }

    private void OnDestroy()
    {
        RightGrabReference.action.started -= AllowRightTeleport;
    }

    private void AllowRightTeleport(InputAction.CallbackContext context)
    {
        bool isActive = !rightRay.enabled;
        rightRay.enabled = isActive;
    }
}
