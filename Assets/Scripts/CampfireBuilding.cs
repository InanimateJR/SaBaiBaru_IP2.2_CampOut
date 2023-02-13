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

    int bottomLayer;
    int middleLayer;

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
        yield return new WaitForSeconds(1);
        if (!leaves1)
        {
            leaves1 = true;
            Destroy(leaf1);
            leaf2.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves2()
    {
        yield return new WaitForSeconds(1);
        if (!leaves2)
        {
            leaves2 = true;
            Destroy(leaf2);
            leaf3.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves3()
    {
        yield return new WaitForSeconds(1);
        if (!leaves3)
        {
            leaves3 = true;
            Destroy(leaf3);
            leaf4.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves4()
    {
        yield return new WaitForSeconds(1);
        if (!leaves4)
        {
            leaves4 = true;
            Destroy(leaf4);
            sticks1.SetActive(true);
        }
    }
    IEnumerator ChangeStick1()
    {
        yield return new WaitForSeconds(1);
        if (!stick1)
        {
            stick1 = true;
            Destroy(sticks1);
            sticks2.SetActive(true);
        }
    }

    IEnumerator ChangeStick2()
    {
        yield return new WaitForSeconds(1);
        if (!stick2)
        {
            stick2 = true;
            Destroy(sticks2);
            sticks3.SetActive(true);
        }
    }

    IEnumerator ChangeStick3()
    {
        yield return new WaitForSeconds(1);
        if (!stick3)
        {
            stick3 = true;
            Destroy(sticks3);
            sticks4.SetActive(true);
        }
    }

    IEnumerator ChangeStick4()
    {
        yield return new WaitForSeconds(1);
        if (!stick4)
        {
            stick4 = true;
            Destroy(sticks4);
            logs1.SetActive(true);
        }
    }

    IEnumerator ChangeLog1()
    {
        yield return new WaitForSeconds(1);
        if (!log1)
        {
            log1 = true;
            Destroy(logs1);
            logs2.SetActive(true);
        }
    }

    IEnumerator ChangeLog2()
    {
        yield return new WaitForSeconds(1);
        if (!log2)
        {
            log2 = true;
            Destroy(logs2);
            logs3.SetActive(true);
        }
    }
    IEnumerator ChangeLog3()
    {
        yield return new WaitForSeconds(1);
        if (!log3)
        {
            log3 = true;
            Destroy(logs3);
            logs4.SetActive(true);
        }
    }
    IEnumerator ChangeLog4()
    {
        yield return new WaitForSeconds(1);
        if (!log4)
        {
            log4 = true;
            Destroy(logs4);
            logs5.SetActive(true);
        }
    }
    IEnumerator ChangeLog5()
    {
        yield return new WaitForSeconds(1);
        if (!log5)
        {
            log5 = true;
            Destroy(logs5);
            logs6.SetActive(true);
        }
    }
    IEnumerator ChangeLog6()
    {
        yield return new WaitForSeconds(1);
        if (!log6)
        {
            log6 = true;
            Destroy(logs6);
            sticks5.SetActive(true);
        }
    }
    IEnumerator ChangeStick5()
    {
        yield return new WaitForSeconds(1);
        if (!stick5)
        {
            stick5 = true;
            Destroy(sticks5);
            sticks6.SetActive(true);
        }
    }
    IEnumerator ChangeStick6()
    {
        yield return new WaitForSeconds(1);
        if (!stick6)
        {
            stick6 = true;
            Destroy(sticks6);
            sticks7.SetActive(true);
        }
    }
    IEnumerator ChangeStick7()
    {
        yield return new WaitForSeconds(1);
        if (!stick7)
        {
            stick7 = true;
            Destroy(sticks7);
            campfireAssembled = true;
            cookingSticks.SetActive(true);
            fireLighting.SetActive(true);
        }
    }
}
