using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CampfireBuilding : MonoBehaviour
{
    bool leaves1 = false;
    bool leaves2 = false;
    bool leaves3 = false;
    bool leaves4 = false;
    bool leaves5 = false;
    bool leaves6 = false;
    bool leaves7 = false;
    bool leaves8 = false;

    bool stick1 = false;
    bool stick2 = false;
    bool stick3 = false;
    bool stick4 = false;
    bool log1 = false;
    bool log2 = false;
    bool log3 = false;

    bool stick5 = false;
    bool stick6 = false;
    bool stick7 = false;
    bool log4 = false;
    bool log5 = false;
    bool log6 = false;

    public GameObject leaf1;
    public GameObject leaf2;
    public GameObject leaf3;
    public GameObject leaf4;

    public GameObject sticks1;
    public GameObject sticks2;
    public GameObject sticks3;
    public GameObject sticks4;
    public GameObject logs1;
    public GameObject logs2;
    public GameObject logs3;

    public GameObject logs4;
    public GameObject logs5;
    public GameObject logs6;
    public GameObject sticks5;
    public GameObject sticks6;
    public GameObject sticks7;

    public GameObject leaf1Hologram;
    public GameObject leaf2Hologram;
    public GameObject leaf3Hologram;
    public GameObject leaf4Hologram;

    public GameObject sticks1Hologram;
    public GameObject sticks2Hologram;
    public GameObject sticks3Hologram;
    public GameObject sticks4Hologram;
    public GameObject logs1Hologram;
    public GameObject logs2Hologram;
    public GameObject logs3Hologram;

    public GameObject logs4Hologram;
    public GameObject logs5Hologram;
    public GameObject logs6Hologram;
    public GameObject sticks5Hologram;
    public GameObject sticks6Hologram;
    public GameObject sticks7Hologram;

    bool campfireAssembled = false;
    public GameObject cookingSticks;
    public GameObject fireLighting;
    private void Update()
    {
        if (campfireAssembled)
        {

        }
    }
    public void Leaves1Placed()
    {
        StartCoroutine(ChangeLeaves1());
    }
    public void Leaves2Placed()
    {
        StartCoroutine(ChangeLeaves2());
    }
    public void Leaves3Placed()
    {
        StartCoroutine(ChangeLeaves3());
    }
    public void Leaves4Placed()
    {
        StartCoroutine(ChangeLeaves4());
    }

    public void Sticks1Placed()
    {
        StartCoroutine(ChangeStick1());
    }
    public void Sticks2Placed()
    {
        StartCoroutine(ChangeStick2());
    }
    public void Sticks3Placed()
    {
        StartCoroutine(ChangeStick3());
    }
    public void Sticks4Placed()
    {
        StartCoroutine(ChangeStick4());
    }

    public void Log1Placed()
    {
        StartCoroutine(ChangeLog1());
    }
    public void Log2Placed()
    {
        StartCoroutine(ChangeLog2());
    }
    public void Log3Placed()
    {
        StartCoroutine(ChangeLog3());
    }

    public void Log4Placed()
    {
        StartCoroutine(ChangeLog4());
    }

    public void Log5Placed()
    {
        StartCoroutine(ChangeLog5());
    }

    public void Log6Placed()
    {
        StartCoroutine(ChangeLog6());
    }

    public void Sticks5Placed()
    {
        StartCoroutine(ChangeStick5());
    }

    public void Sticks6Placed()
    {
        StartCoroutine(ChangeStick6());
    }

    public void Sticks7Placed()
    {
        StartCoroutine(ChangeStick7());
    }
    IEnumerator ChangeLeaves1()
    {
        
        if (!leaves1)
        {
            leaf1Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            leaves1 = true;
            leaf1.SetActive(false);
            leaf2.SetActive(true);
            leaf2Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves2()
    {

        if (!leaves2)
        {
            leaf2Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            leaves2 = true;
            leaf2.SetActive(false);
            leaf3.SetActive(true);
            leaf3Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves3()
    {
        if (!leaves3)
        {
            leaf3Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            leaves3 = true;
            leaf3.SetActive(false);
            leaf4.SetActive(true);
            leaf4Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves4()
    {
        if (!leaves4)
        {
            leaf4Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            leaves4 = true;
            leaf4.SetActive(false);
            sticks1.SetActive(true);
            sticks1Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeStick1()
    {
        if (!stick1)
        {
            sticks1Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            stick1 = true;
            sticks1.SetActive(false);
            sticks2.SetActive(true);
            sticks2Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeStick2()
    {
        if (!stick2)
        {
            sticks2Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            stick2 = true;
            sticks2.SetActive(false);
            sticks3.SetActive(true);
            sticks3Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeStick3()
    {
        if (!stick3)
        {
            sticks3Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            stick3 = true;
            sticks3.SetActive(false);
            sticks4.SetActive(true);
            sticks4Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeStick4()
    {
        if (!stick4)
        {
            sticks4Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            stick4 = true;
            sticks4.SetActive(false);
            logs1.SetActive(true);
            logs1Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeLog1()
    {
        if (!log1)
        {
            logs1Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            log1 = true;
            logs1.SetActive(false);
            logs2.SetActive(true);
            logs2Hologram.SetActive(true);
        }
    }

    IEnumerator ChangeLog2()
    {
        if (!log2)
        {
            logs2Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            log2 = true;
            logs2.SetActive(false);
            logs3.SetActive(true);
            logs3Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeLog3()
    {
        if (!log3)
        {
            logs3Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            log1 = true;
            logs3.SetActive(false);
            logs4.SetActive(true);
            logs4Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeLog4()
    {
        if (!log4)
        {
            logs4Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            log4 = true;
            logs4.SetActive(false);
            logs5.SetActive(true);
            logs5Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeLog5()
    {
        if (!log5)
        {
            logs5Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            log5 = true;
            logs5.SetActive(false);
            logs6.SetActive(true);
            logs6Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeLog6()
    {
        if (!log6)
        {
            logs6Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            log6 = true;
            logs6.SetActive(false);
            sticks5.SetActive(true);
            sticks5Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeStick5()
    {
        if (!stick5)
        {
            sticks5Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            stick5 = true;
            sticks5.SetActive(false);
            sticks6.SetActive(true);
            sticks6Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeStick6()
    {
        if (!stick6)
        {
            sticks6Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            stick6 = true;
            sticks6.SetActive(false);
            sticks7.SetActive(true);
            sticks6Hologram.SetActive(true);
        }
    }
    IEnumerator ChangeStick7()
    { 
        if (!stick7)
        {
            sticks7Hologram.SetActive(false);
            yield return new WaitForSeconds(1);
            stick7 = true;
            sticks7.SetActive(false);
            campfireAssembled = true;
            cookingSticks.SetActive(true);
            fireLighting.SetActive(true);
        }
    }
}
