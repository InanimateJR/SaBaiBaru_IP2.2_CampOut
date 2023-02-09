using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerAnimScript : MonoBehaviour
{
    private Animator Anim;

    private Animator otherAnim;

    public GameObject settingsBtn;
    public GameObject taskBtn;
    public GameObject guideBtn;

    public GameObject settingsSection;
    public GameObject guideSection;
    public GameObject taskSection;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        if (settingsSection.activeSelf == true)
        {
            Anim.Play("SettingsOpen_Animation");
        }
        if (guideSection.activeSelf == true)
        {
            Anim.Play("GuideOpen_Animation");
        }
        if (taskSection.activeSelf == true)
        {
            Anim.Play("TaskOpen_Animation");
        }
    }

    public void GuideOpen()
    {
        Anim.Play("GuideOpen_Animation");

        guideSection.SetActive(true);

        if (settingsSection.activeSelf == true)
        {

            otherAnim = settingsBtn.GetComponent<Animator>();
            otherAnim.Play("SettingsClose_Animation");
            settingsSection.SetActive(false);
        }
        else if (taskSection.activeSelf == true)
        {
            otherAnim = taskBtn.GetComponent<Animator>();
            otherAnim.Play("TaskClose_Animation");
            taskSection.SetActive(false);
        }
    }

    public void TaskOpen()
    {
        Anim.Play("TaskOpen_Animation");

        taskSection.SetActive(true);

        if (settingsSection.activeSelf == true)
        {
            otherAnim = settingsBtn.GetComponent<Animator>();
            otherAnim.Play("SettingsClose_Animation");
            settingsSection.SetActive(false);
        }
        else if (guideSection.activeSelf == true)
        {
            otherAnim = guideBtn.GetComponent<Animator>();
            otherAnim.Play("GuideClose_Animation");
            guideSection.SetActive(false);
        }
    }

    public void SettingsOpen()
    {
        Anim.Play("SettingsOpen_Animation");

        settingsSection.SetActive(true);

        if (taskSection.activeSelf == true)
        {
            otherAnim = taskBtn.GetComponent<Animator>();
            otherAnim.Play("TaskClose_Animation");
            taskSection.SetActive(false);
        }
        else if (guideSection.activeSelf == true)
        {
            otherAnim = guideBtn.GetComponent<Animator>();
            otherAnim.Play("GuideClose_Animation");
            guideSection.SetActive(false);
        }
    }


}
