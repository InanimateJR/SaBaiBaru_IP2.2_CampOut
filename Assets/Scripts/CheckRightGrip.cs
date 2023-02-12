using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckRightGrip : MonoBehaviour
{
    public TeleportRayScript teleportRayScript;

    public InputActionReference RightGrabReference = null;

    private void Awake()
    {
        RightGrabReference.action.performed += GripButton;
        RightGrabReference.action.canceled += GripButton;
    }

    private void OnDestroy()
    {
        RightGrabReference.action.performed -= GripButton;
        RightGrabReference.action.canceled -= GripButton;
    }

    private void GripButton(InputAction.CallbackContext context)
    {
        teleportRayScript.rightControllerGrip = context.performed;
    }
}
