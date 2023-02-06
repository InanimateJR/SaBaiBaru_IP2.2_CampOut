using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text text;

    public void TextScale(Slider slider)
    {
        text.fontSize = (int)slider.value;
        Debug.Log((int)slider.value);
    }
}
