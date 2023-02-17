using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardScript : MonoBehaviour
{
    public InputFieldManager inputFieldManager;

    string[] capsLetters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    string[] smallLetters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
    string[] symbols = { "@", "." };

    public void InputDetected()
    {
        foreach (string capsLetter in capsLetters)
        {
            // Check if the game object name matches the current capsLetter
            if (this.gameObject.name == capsLetter)
            {
                // Add the letter to the input field
                inputFieldManager.currentInput.text += capsLetter;
                break;
            }
        }

        foreach (string smallLetter in smallLetters)
        {
            // Check if the game object name matches the current smallLetter
            if (this.gameObject.name == smallLetter)
            {
                // Add the letter to the input field
                inputFieldManager.currentInput.text += smallLetter;
                break;
            }
        }

        foreach (string number in numbers)
        {
            // Check if the game object name matches the current number
            if (this.gameObject.name == number)
            {
                // Add the number to the input field
                inputFieldManager.currentInput.text += number;
                break;
            }
        }

        foreach (string symbol in symbols)
        {
            // Check if the game object name matches the current symbol
            if (this.gameObject.name == symbol)
            {
                // Add the synmbol to the input field
                inputFieldManager.currentInput.text += symbol;
                break;
            }
        }

        if (this.gameObject.name == "Backspace")
        {
            // Remove one character from input field
            inputFieldManager.currentInput.text = inputFieldManager.currentInput.text.Substring(0, inputFieldManager.currentInput.text.Length - 1);
        }

        if (this.gameObject.name == "Keyboard")
        {
            inputFieldManager.ToggleKeyboard();
        }

        if (this.gameObject.name == ".com")
        {
            inputFieldManager.currentInput.text += ".com";
        }

        if (this.gameObject.name == "Caps")
        {
            inputFieldManager.ToggleCaps();
        }
    }
}
