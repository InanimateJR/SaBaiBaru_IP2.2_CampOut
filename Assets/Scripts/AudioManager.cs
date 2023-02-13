using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource rangerSFX;
    public AudioSource fishermanSFX;
    public AudioSource journalFlippingSFX;
    public AudioSource collectSticksSFX;
    public AudioSource collectLeavesSFX;
    public AudioSource vanStartEngineSFX;
    public AudioSource vanEngineSFX;

    public int finishedCount;

    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        }
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            audioMixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume"));
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RangerAudioOn()
    {
        rangerSFX.Play();
    }
    public void RangerAudioOff()
    {
        rangerSFX.Stop();
    }

    public void FishermanAudioOn()
    {
        fishermanSFX.Play();
    }

    public void FishermanAudioOff()
    {
        fishermanSFX.Stop();
    }

    public void JournalFlippingAudio()
    {
        journalFlippingSFX.Play();
    }
    public void CollectSticksAudio()
    {
        collectSticksSFX.Play();
    }
    public void CollectLeavesAudio()
    {
        collectLeavesSFX.Play();
    }
    public void VanStartEngineAudio()
    {
        vanStartEngineSFX.Play();
        if (!vanStartEngineSFX.isPlaying)
        {
            finishedCount++;
            if (finishedCount > 1)
            {
                vanEngineSFX.Play();
            }
        }
    }
    public void VanEngineAudio()
    {
        vanEngineSFX.Play();
    }

}
