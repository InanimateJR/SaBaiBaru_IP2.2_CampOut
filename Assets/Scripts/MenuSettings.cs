using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text text;
    public TMP_Text sfxVolume;
    public TMP_Text bgmVolume;
    public TMP_Text textSize;
    public AudioMixer mixer1;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        //float volume = 20f;
       // mixer1.GetFloat("BGMVolume", out volume);
        //bgmSlider.value = volume;
        //mixer1.GetFloat("SFXVolume", out volume);
        //sfxSlider.value = volume;
    }
    public void TextScale(Slider slider)
    {
        text.fontSize = (int)slider.value;
        Debug.Log((int)slider.value);
        textSize.text = (slider.value.ToString());
        textSize.fontSize = (int)slider.value;

    }

    public void SFXScale(Slider slider)
    {
        sfxVolume.text = ((int)slider.value + 80).ToString();
        mixer1.SetFloat("SFXVolume", slider.value);
    }

    public void BGMScale(Slider slider)
    {
        bgmVolume.text = ((int)slider.value + 80).ToString();
        mixer1.SetFloat("BGMVolume", slider.value);
    }
}
