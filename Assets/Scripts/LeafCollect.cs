using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCollect : MonoBehaviour
{
    public bool collected = false;
    public int score;
    public GameObject notepad;
    // Start is called before the first frame update
    void Start()
    {
        notepad = GameObject.Find("Notepad 7.0");
    }

    // Update is called once per frame
    public void CollectLeaf()
    {
        if (!collected)
        {
            collected = true;
            notepad.GetComponent<TaskLog>().LeafCollection();
        }
    }
}
