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

    public GameObject middleLayerGroup;
    public GameObject topLayerGroup;

    public GameObject leaf1;
    public GameObject leaf2;
    public GameObject leaf3;
    public GameObject leaf4;
    public GameObject leaf5;
    public GameObject leaf6;
    public GameObject leaf7;
    public GameObject leaf8;

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
    public void Leaves5Placed()
    {
        StartCoroutine(ChangeLeaves5());
    }

    public void Leaves6Placed()
    {
        StartCoroutine(ChangeLeaves6());
    }
    public void Leaves7Placed()
    {
        StartCoroutine(ChangeLeaves7());
    }

    public void Leaves8Placed()
    {
        StartCoroutine(ChangeLeaves8());
    }

    public void Sticks1Placed()
    {
        StartCoroutine(ChangeStick1());
    }
    public void Sticks2Placed()
    {

    }
    public void Sticks3Placed()
    {

    }
    public void Sticks4Placed()
    {

    }

    public void Log1Placed()
    {

    }
    public void Log2Placed()
    {

    }
    public void Log3Placed()
    {

    }
    
    IEnumerator ChangeLeaves1()
    {
        yield return new WaitForSeconds(2);
        if (!leaves1)
        {
            leaves1 = true;
            Destroy(leaf1);
            leaf2.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves2()
    {
        yield return new WaitForSeconds(2);
        if (!leaves2)
        {
            leaves2 = true;
            Destroy(leaf2);
            leaf3.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves3()
    {
        yield return new WaitForSeconds(2);
        if (!leaves3)
        {
            leaves3 = true;
            Destroy(leaf3);
            leaf4.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves4()
    {
        yield return new WaitForSeconds(2);
        if (!leaves4)
        {
            leaves4 = true;
            Destroy(leaf4);
            leaf5.SetActive(true);
        }
    }
    IEnumerator ChangeLeaves5()
    {
        yield return new WaitForSeconds(2);
        if (!leaves5)
        {
            leaves5 = true;
            Destroy(leaf5);
            leaf6.SetActive(true);
        }
    }

    IEnumerator ChangeLeaves6()
    {
        yield return new WaitForSeconds(2);
        if (!leaves6)
        {
            leaves6 = true;
            Destroy(leaf6);
            leaf7.SetActive(true);
        }
    }
    IEnumerator ChangeLeaves7()
    {
        yield return new WaitForSeconds(2);
        if (!leaves7)
        {
            leaves7 = true;
            Destroy(leaf7);
            leaf8.SetActive(true);
        }
    }
    IEnumerator ChangeLeaves8()
    {
        yield return new WaitForSeconds(2);
        if (!leaves8)
        {
            leaves8 = true;
            Destroy(leaf8);
            sticks1.SetActive(true);
        }
    }
    IEnumerator ChangeStick1()
    {
        yield return new WaitForSeconds(2);
        if (!stick1)
        {
            stick1 = true;
            Destroy(sticks1);
            sticks2.SetActive(true);
        }
    }
}
