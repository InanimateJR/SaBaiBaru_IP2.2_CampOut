using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckLeftGrip : MonoBehaviour
{
    public TeleportRayScript teleportRayScript;

    public InputActionReference LeftGrabReference = null;

    private void Awake()
    {
        LeftGrabReference.action.performed += GripButton;
        LeftGrabReference.action.canceled += GripButton;
    }

    private void OnDestroy()
    {
        LeftGrabReference.action.performed -= GripButton;
        LeftGrabReference.action.canceled -= GripButton;
    }

    private void GripButton(InputAction.CallbackContext context)
    {
        teleportRayScript.leftControllerGrip = context.performed;
    }
}
