using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldManager : MonoBehaviour
{
    public TMPro.TMP_InputField currentInput;
    public TMPro.TMP_InputField loginEmailInput;
    public TMPro.TMP_InputField loginPasswordInput;
    public TMPro.TMP_InputField registerEmailInput;
    public TMPro.TMP_InputField registerPasswordInput;
    public TMPro.TMP_InputField registerUsernameInput;

    public GameObject keyboard;
    public GameObject capsLetters;
    public GameObject smallLetters;

    public void SelectLoginEmail()
    {
        currentInput = loginEmailInput;
    }

    public void SelectLoginPassword()
    {
        currentInput = loginPasswordInput;
    }

    public void SelectRegisterEmail()
    {
        currentInput = registerEmailInput;
    }

    public void SelectRegisterPassword()
    {
        currentInput = registerPasswordInput;
    }

    public void SelectRegisterUsername()
    {
        currentInput = registerUsernameInput;
    }

    public void ToggleKeyboard()
    {
        if (keyboard.activeSelf)
        {
            keyboard.SetActive(false);
        }

        else
        {
            keyboard.SetActive(true);
        }
    }

    public void ToggleCaps()
    {
        if (capsLetters.activeSelf && !smallLetters.activeSelf)
        {
            capsLetters.SetActive(false);
            smallLetters.SetActive(true);
        }
        else if (!capsLetters.activeSelf && smallLetters.activeSelf)
        {
            capsLetters.SetActive(true);
            smallLetters.SetActive(false);
        }
    }
}
