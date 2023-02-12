using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckRightButton2 : MonoBehaviour
{
    public TeleportRayScript teleportRayScript;

    public InputActionReference RightButton2Reference = null;

    private void Awake()
    {
        RightButton2Reference.action.performed += Button2;
        RightButton2Reference.action.canceled += Button2;
    }

    private void OnDestroy()
    {
        RightButton2Reference.action.performed -= Button2;
        RightButton2Reference.action.canceled -= Button2;
    }

    private void Button2(InputAction.CallbackContext context)
    {
        teleportRayScript.rightControllerButton2 = context.performed;
    }
}
