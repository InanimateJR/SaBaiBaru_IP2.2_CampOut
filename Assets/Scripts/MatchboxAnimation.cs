using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchboxAnimation : MonoBehaviour
{
    public Animator matchboxParent;

    public void ChangeAnimation()
    {
        if (matchboxParent.GetBool("MatchboxOpen"))
        {
            Debug.Log("MatchboxOpen");
            matchboxParent.SetBool("MatchboxOpen", false);
            matchboxParent.SetBool("MatchboxClose", true);
        }

        else if (matchboxParent.GetBool("MatchboxClose"))
        {
            Debug.Log("MatchboxClose");
            matchboxParent.SetBool("MatchboxClose", false);
            matchboxParent.SetBool("MatchboxOpen", true);
        }

        else
        {
            matchboxParent.SetBool("MatchboxOpen", true);
        }
    }
}
