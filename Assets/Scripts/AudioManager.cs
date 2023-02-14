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
    public AudioSource collectStickSFX;
    public AudioSource collectLeavesSFX;
    public AudioSource vanStartEngineSFX;
    public AudioSource vanEngineSFX;
    public AudioSource collectFoodSFX;
    public AudioSource collectFishSFX;
    public AudioSource castLineSFX;
    public AudioSource fishingSFX;
    public AudioSource tentSFX1;
    public AudioSource tentSFX2;
    public AudioSource tentSFX3;

    private bool vanStarted;

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
    void FixedUpdate()
    {
        if (vanStarted == true)
        {
            Debug.Log("Van started");
            if(!vanStartEngineSFX.isPlaying)
            {
                Debug.Log("Van start engine finished playing");
                VanEngineAudio();
                vanStarted = false;
            }
            
        }
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
    public void CollectStickAudio()
    {
        collectStickSFX.Play();
    }
    public void CollectLeavesAudio()
    {
        collectLeavesSFX.Play();
    }
    public void VanStartEngineAudio()
    {
        vanStartEngineSFX.Play();
        vanStarted = true;
    }
    public void VanEngineAudio()
    {
        Debug.Log("Van Engine SFX Playing");
        vanEngineSFX.Play();
    }

    public void CollectFoodAudio()
    {
        collectFoodSFX.Play();
    }

    public void CollectFishAudio()
    {
        collectFishSFX.Play();
    }
    public void CastLineAudio()
    {
        castLineSFX.Play();
    }
    public void FishingAudio()
    {
        fishingSFX.Play();
    }
}
