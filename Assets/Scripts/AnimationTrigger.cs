using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private int collisionCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        collisionCount++;
        //on collision, play animation
        if (collisionCount <= 3)
        {
            GetComponent<Animation>().Play();
        }
    }
}