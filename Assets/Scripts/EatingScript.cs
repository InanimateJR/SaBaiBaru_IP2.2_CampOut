using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingScript : MonoBehaviour
{

    public GameObject poisonEffect1;
    public GameObject poisonEffect2;
    public GameObject poisonEffect3;
    public GameObject poisonEffect4;

    public bool eatenFood = false;
    public TaskLog taskLogScript;
    public GameObject endGame;

    private void OnTriggerEnter(Collider other)
    {
        //If the food is cooked Mushroom
        if (other.gameObject.tag == "Cooked Edible Mushroom")
        {
           
            if (!eatenFood)
            {
                taskLogScript.EatenFood();
                eatenFood = true;
            }
            
            Destroy(other.gameObject);
            Debug.Log("Edible Mushroom has been eaten");
            endGame.SetActive(true);
        }
        //If the food is cooked Fish
        else if (other.gameObject.tag == "Cooked Fish")
        {
            if (!eatenFood)
            {
                taskLogScript.EatenFood();
                eatenFood = true;
            }

            Destroy(other.gameObject);
            Debug.Log("Fish has been eaten");
            endGame.SetActive(true);
        }
        //If the food is cooked Poison Mushroom, it will disappear and also call function to create poison effect for 20-30s.
        else if (other.gameObject.tag == "Cooked Poison Mushroom")
        {
            
            Destroy(other.gameObject);
            int effect = Random.Range(1, 5);
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
                poisonEffect3.SetActive(true);
                StartCoroutine(PoisonEffect());
            }
            else if (effect == 4)
            {
                poisonEffect4.SetActive(true);
                StartCoroutine(PoisonEffect());
            }
            Debug.Log("Poison has been eaten");
        }

        
    }
    //function to create one of the four poison effect for about 20-30s randomly
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
            poisonEffect3.SetActive(false);
        }
        else if (poisonEffect4.activeSelf)
        {
            poisonEffect4.SetActive(false);
        }
        Debug.Log("Poison Effect is now gone");
    }

}
