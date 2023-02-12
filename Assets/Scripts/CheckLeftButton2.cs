using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckLeftButton2 : MonoBehaviour
{
    public TeleportRayScript teleportRayScript;

    public InputActionReference LeftButton2Reference = null;

    private void Awake()
    {
        LeftButton2Reference.action.performed += Button2;
        LeftButton2Reference.action.canceled += Button2;
    }

    private void OnDestroy()
    {
        LeftButton2Reference.action.performed -= Button2;
        LeftButton2Reference.action.canceled -= Button2;
    }

    private void Button2(InputAction.CallbackContext context)
    {
        teleportRayScript.leftControllerButton2 = context.performed;
    }
}
