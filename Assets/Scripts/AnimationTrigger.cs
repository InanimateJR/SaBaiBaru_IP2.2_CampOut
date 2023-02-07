using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public AnimationClip animationClip;
    private int hits = 0;
    private Animation animation;

    private void Start()
    {
        animation = GetComponent<Animation>();
        animation.clip = animationClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hits < 3)
        {
            hits++;
            animation.Play();
        }
    }
}
