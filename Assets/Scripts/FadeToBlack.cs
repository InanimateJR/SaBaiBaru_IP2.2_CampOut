using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackOutSquare;
    public AudioManager audioManager;
    public GameObject camperVan;

    public IEnumerator FadeBlackOutSquare(bool fadetoBlack = true, int fadeSpeed = 3)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadetoBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else
        {
            while(blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent <Image>().color = objectColor;
                yield return null;
            }
        }
    }
    public IEnumerator BlackandWait()
    {
        StartCoroutine(FadeBlackOutSquare());
        audioManager.VanStartEngineAudio();
        camperVan.SetActive(true);
        yield return new WaitForSeconds(4);
        StartCoroutine(FadeBlackOutSquare(false));
    }

    public void BlackOut()
    {
        StartCoroutine(BlackandWait());
        
    }
}
