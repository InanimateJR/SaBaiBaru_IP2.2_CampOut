using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentButtonScript : MonoBehaviour
{
    public TentScript tentScript1;
    public TentScript tentScript2;
    public TentScript tentScript3;

    public void SnappedTentSocket1()
    {
        tentScript1.snappedSocket1 = true;
    }

    public void SnappedTentSocket2()
    {
        tentScript2.snappedSocket2 = true;
    }

    public void SnappedTentSocket3()
    {
        tentScript3.snappedSocket3 = true;
    }

    public void RemovedTentSocket1()
    {
        tentScript1.snappedSocket1 = false;
    }

    public void RemovedTentSocket2()
    {
        tentScript2.snappedSocket2 = false;
    }

    public void RemovedTentSocket3()
    {
        tentScript3.snappedSocket3 = false;
    }

    public void PitchTent()
    {
        if (tentScript1.snappedSocket1 == true)
        {
            tentScript1.StartTentPitching();
        }

        if (tentScript2.snappedSocket1 == true)
        {
            tentScript2.StartTentPitching();
        }

        if (tentScript3.snappedSocket1 == true)
        {
            tentScript3.StartTentPitching();
        }
    }
}
