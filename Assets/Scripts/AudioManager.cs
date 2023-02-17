using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioManager audioMgr;
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
    public AudioSource[] matchstickSFX;
    public AudioSource tent1Peg1HitSFX;
    public AudioSource tent1Peg2HitSFX;
    public AudioSource tent1Peg3HitSFX;
    public AudioSource tent1Peg4HitSFX;
    public AudioSource tent2Peg1HitSFX;
    public AudioSource tent2Peg2HitSFX;
    public AudioSource tent2Peg3HitSFX;
    public AudioSource tent2Peg4HitSFX;
    public AudioSource tent3Peg1HitSFX;
    public AudioSource tent3Peg2HitSFX;
    public AudioSource tent3Peg3HitSFX;
    public AudioSource tent3Peg4HitSFX;
    public AudioSource tutorialBGM;

    private bool vanStarted;

    private GameObject currentAudioManager;
    private void Awake()
    {
        currentAudioManager = GameObject.Find("AudioManager");    
    }

    void Start()
    {

        audioMgr = currentAudioManager.GetComponent<AudioManager>();

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
        audioMgr.rangerSFX.Play();
    }
    public void RangerAudioOff()
    {
        audioMgr.rangerSFX.Stop();
    }

    public void FishermanAudioOn()
    {
        audioMgr.fishermanSFX.Play();
    }

    public void FishermanAudioOff()
    {
        audioMgr.fishermanSFX.Stop();
    }

    public void JournalFlippingAudio()
    {
        audioMgr.journalFlippingSFX.Play();
    }
    public void CollectStickAudio()
    {
        audioMgr.collectStickSFX.Play();
    }
    public void CollectLeavesAudio()
    {
        audioMgr.collectLeavesSFX.Play();
    }
    public void VanStartEngineAudio()
    {
        audioMgr.vanStartEngineSFX.Play();
        audioMgr.vanStarted = true;
    }
    public void VanEngineAudio()
    {
        Debug.Log("Van Engine SFX Playing");
        audioMgr.vanEngineSFX.Play();
    }

    public void CollectFoodAudio()
    {
        if (audioMgr != null)
        {
            Debug.Log("Play Sound");
            audioMgr.collectFoodSFX.Play();
        }
    }

    public void CollectFishAudio()
    { 
        if (audioMgr != null)
        {
            audioMgr.collectFishSFX.Play();
        }
    }
    public void CastLineAudio()
    {
        audioMgr.castLineSFX.Play();
    }
    public void FishingAudio()
    {
        audioMgr.fishingSFX.Play();
    }

    public void TentSFX1Audio()
    {
        audioMgr.tentSFX1.Play();
    }
    public void TentSFX2Audio()
    {
        audioMgr.tentSFX2.Play();
    }
    public void TentSFX3Audio()
    {
        audioMgr.tentSFX3.Play();
    }
}
