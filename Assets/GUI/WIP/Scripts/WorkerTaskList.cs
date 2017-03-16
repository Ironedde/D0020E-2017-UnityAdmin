using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Task
{
    public string TaskName;
    public string Desc;
}

public class WorkerTaskList : MonoBehaviour {

    public List<Task> taskList;
    public Transform contentPanel;
    public Text Description; 
    public SimpleObjectPool buttonObjectPool;

    private Task listTask;

    // Use this for initialization
    void Start () {
        taskUpdate();
        RefreshDisplay();
	}

    public void taskUpdate()
    {
        //Här bör inläsning, texthantering, eventuell timer och skapandet av tasklist ske
        listTask = new Task();
        listTask.TaskName = "1. Pick up your tools";
        listTask.Desc = "Get the following items:" + "\n"
            + "Helmet" + "\n"
            + "Wrench" + "\n"
            + "Flashlight" + "\n"
            + "status: Finished";
        taskList.Add(listTask);

        listTask = new Task();
        listTask.TaskName = "2. Repair machine";
        listTask.Desc = "Repair the machine" + "\n" + "status: Done";
        taskList.Add(listTask);

        listTask = new Task();
        listTask.TaskName = "3. Coffee Break";
        listTask.Desc = "30 min of Coffee quaffing." + "\n" + "status: ayup";
        taskList.Add(listTask);

        listTask = new Task();
        listTask.TaskName = "4. Return the tools";
        listTask.Desc = "Tools returned" + "\n" + "status: Task complete";
        taskList.Add(listTask);
    }

    public void RefreshDisplay()
    {
        AddButtons();
    }
	
    private void AddButtons()
    {
        for (int i = 0; i < taskList.Count; i++)
        {
            Task task = taskList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            TaskButtonScript taskButton = newButton.GetComponent<TaskButtonScript>();
            taskButton.Setup(task, this);
        }
    }
   
    public void ShowTaskDesc(Task clickedTask)
    {
        Description.text = clickedTask.Desc;
    }
}
