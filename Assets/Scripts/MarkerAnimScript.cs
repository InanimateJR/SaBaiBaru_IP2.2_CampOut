using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerAnimScript : MonoBehaviour
{
    private Animator Anim;

    public GameObject guideSection;

    public GameObject settingSection;

    public GameObject taskSection;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void GuideOpen()
    {
        if(taskSection.activeSelf)
        {
            Anim.Play("GuideOpen_Animation");

        }
        else if(settingSection.activeSelf)
        {
            Anim.Play("GuideOpen_Animation");

        }
    }


}
