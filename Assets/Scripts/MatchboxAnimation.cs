using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchboxAnimation : MonoBehaviour
{
    public Animator matchboxAnimator;

    public void ChangeAnimation()
    {
        if (matchboxAnimator.GetBool("MatchboxOpen"))
        {
            Debug.Log("MatchboxOpen");
            matchboxAnimator.SetBool("MatchboxOpen", false);
            matchboxAnimator.SetBool("MatchboxClose", true);
        }

        else if (matchboxAnimator.GetBool("MatchboxClose"))
        {
            Debug.Log("MatchboxClose");
            matchboxAnimator.SetBool("MatchboxClose", false);
            matchboxAnimator.SetBool("MatchboxOpen", true);
        }

        else
        {
            matchboxAnimator.SetBool("MatchboxOpen", true);
        }
    }
}
