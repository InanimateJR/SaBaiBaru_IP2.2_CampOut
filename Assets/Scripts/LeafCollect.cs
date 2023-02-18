using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCollect : MonoBehaviour
{
    public bool collected = false;
    public int score;
    public GameObject notepad;
    public TaskLog taskLogScript;

    private void Awake()
    {
        notepad = GameObject.Find("Notepad 7.0");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (notepad != null)
        {
            taskLogScript = notepad.GetComponent<TaskLog>();
        }

    }

    // when collected, calls task log function
    public void CollectLeaf()
    {
        if (!collected)
        {
            collected = true;
            taskLogScript.LeafCollection();
        }
    }
}
