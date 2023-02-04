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
    int topLayer;

    public GameObject middleLayerGroup;
    public GameObject topLayerGroup;

    public void Leaves1Placed()
    {
        if (!leaves1)
        {
            leaves1 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }
    public void Leaves2Placed()
    {
        if (!leaves2)
        {
            leaves2 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }
    public void Leaves3Placed()
    {
        if (!leaves3)
        {
            leaves3 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }
    public void Leaves4Placed()
    {
        if (!leaves4)
        {
            leaves4 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }
    public void Leaves5Placed()
    {
        if (!leaves5)
        {
            leaves5 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }

    public void Leaves6Placed()
    {
        if (!leaves6)
        {
            leaves6 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }
    public void Leaves7Placed()
    {
        if (!leaves7)
        {
            leaves7 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }

    public void Leaves8Placed()
    {
        if (!leaves8)
        {
            leaves8 = true;
            bottomLayer++;
            CheckBottomLayer();
        }
    }

    public void CheckBottomLayer()
    {
        if (bottomLayer == 8)
        {
            middleLayerGroup.SetActive(true);
        }
    }
}
