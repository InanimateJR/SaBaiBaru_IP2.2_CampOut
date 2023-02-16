using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text sfxVolume;
    public TMP_Text bgmVolume;
    public AudioMixer mixer1;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public GameObject notepad;

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
