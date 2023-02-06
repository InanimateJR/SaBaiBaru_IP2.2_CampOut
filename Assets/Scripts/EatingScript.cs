using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingScript : MonoBehaviour
{

    public GameObject poisonEffect1;
    public GameObject poisonEffect2;
    public GameObject poisonEffect3;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cooked Edible Mushroom")
        {
            
            Destroy(other.gameObject);
            Debug.Log("Edible Mushroom has been eaten");
        }
        else if (other.gameObject.tag == "Cooked Fish")
        {

            Destroy(other.gameObject);
            Debug.Log("Fish has been eaten");
        }
        else if (other.gameObject.tag == "Cooked Poison Mushroom")
        {
            Destroy(other.gameObject);
            int effect = Random.Range(1, 4);
            if (effect == 1)
            {
                poisonEffect1.SetActive(true);
                StartCoroutine(PoisonEffect());
            }
            else if (effect == 2)
            {
                poisonEffect2.SetActive(true);
                StartCoroutine(PoisonEffect());
            }
            else if (effect == 3)
            {
                poisonEffect1.SetActive(true);
                StartCoroutine(PoisonEffect());
            }
            Debug.Log("Poison has been eaten");
        }

        
    }
    public IEnumerator PoisonEffect()
    {
        int effectTime = Random.Range(20, 31);
        yield return new WaitForSeconds(effectTime);

        if (poisonEffect1.activeSelf)
        {
            poisonEffect1.SetActive(false);
        }
        else if (poisonEffect2.activeSelf)
        {
            poisonEffect2.SetActive(false);
        }
        else if (poisonEffect3.activeSelf)
        {
            poisonEffect1.SetActive(false);
        }
        Debug.Log("Poison Effect is now gone");
    }

}
