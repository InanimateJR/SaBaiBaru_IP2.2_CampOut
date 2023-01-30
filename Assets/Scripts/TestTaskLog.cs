using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTaskLog : MonoBehaviour
{
    public TMP_Text taskText;
    public bool isCompleted = false;

    void Update()
    {
        taskText.text = "Task Name";
        if (isCompleted)
        {
            taskText.fontStyle = FontStyles.Strikethrough;
        }
        else
        {
            taskText.fontStyle = FontStyles.Normal;
        }
    }

    public void completeTask()
    {
        isCompleted = true;
    }
}
