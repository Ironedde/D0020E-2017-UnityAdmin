using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskButtonScript : MonoBehaviour {
    public Button TaskButton;
    public Text TaskText;

    private Task task;
    private WorkerTaskList taskList;
   
	// Use this for initialization
	void Start () {
        TaskButton.onClick.AddListener(HandleClick);
	}

    public void Setup(Task currentTask, WorkerTaskList currentTaskList)
    {
        task = currentTask;
        TaskText.text = task.TaskName;

        taskList = currentTaskList;
    }

    public void HandleClick()
    {
        taskList.ShowTaskDesc(task);
    }
}
