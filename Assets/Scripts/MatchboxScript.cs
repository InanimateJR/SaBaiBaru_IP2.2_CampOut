using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchboxScript : MonoBehaviour
{
    public float requiredSpeed = 10f;    // Set required velocity of matchstick for it to light 
    public Vector3 position1;
    public Vector3 position2;
    public float timeTaken;
    public bool startTimer;
    public float matchstickSpeed;

    public bool cycleOver;
    public bool findMatchstick;

    private GameObject matchstick;
    private MatchstickScript matchstickScript;

    private void Update()
    {
        if (startTimer)
        {
            timeTaken += Time.deltaTime;
        }

        if (findMatchstick)
        {
            matchstickScript = matchstick.GetComponent<MatchstickScript>();
            findMatchstick = false;
        }

        if (!startTimer && !cycleOver && matchstick != null)
        {
            matchstickSpeed = Vector3.Distance(position1, position2) * 100 / timeTaken;
            if (matchstickSpeed >= requiredSpeed)
            {
                matchstickScript.IgniteMatch();

                cycleOver = true;
            }
        }

        if (matchstick == null)
        {
            cycleOver = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MatchstickTip")
        {
            matchstick = other.gameObject.transform.parent.gameObject;
            findMatchstick = true;
            Debug.Log("Matchstick: " + matchstick);
            Debug.Log("Entered");
            position1 = other.gameObject.transform.position;
            startTimer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MatchstickTip")
        {
            Debug.Log("Exited");
            position2 = other.gameObject.transform.position;
            startTimer = false;
        }
    }
}
