using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Models;
using System.Linq;

public class ActiveWorkersList : MonoBehaviour {
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;
    public SimpleObjectPool hbuttonObjectPool;
    private HighlightButton HButton;
    private List<Person> AddedPersons = new List<Person>();
    private List<GameObject> WorkerButtons = new List<GameObject>();
    private bool DrawListWorkers = false;
    private bool DrawMainMenu = true;
    
    void Start()
    {
    }

    //Conditional Re-drawing of the Menu based on State
    public void RefreshDisplay()
    {
        if (DrawMainMenu)
        {
           AddMenuButtons();
        }
        if (DrawListWorkers)
        {
            AddWorkerButtons();
        }
    }

    //Creates menu buttons from object pool
    private void AddMenuButtons()
    {
        GameObject newHButton;
        newHButton = hbuttonObjectPool.GetObject();
        newHButton.transform.SetParent(contentPanel);
        HButton = newHButton.GetComponent<HighlightButton>();
        HButton.SetState(HighlightButton.State.All, "All");
        
        newHButton = hbuttonObjectPool.GetObject();
        newHButton.transform.SetParent(contentPanel);
        HButton = newHButton.GetComponent<HighlightButton>();
        HButton.SetState(HighlightButton.State.GroupOne, "Group #1");

        newHButton = hbuttonObjectPool.GetObject();
        newHButton.transform.SetParent(contentPanel);
        HButton = newHButton.GetComponent<HighlightButton>();
        HButton.SetState(HighlightButton.State.GroupTwo, "Group #2");

        newHButton = hbuttonObjectPool.GetObject();
        newHButton.transform.SetParent(contentPanel);
        HButton = newHButton.GetComponent<HighlightButton>();
        HButton.SetState(HighlightButton.State.GroupThree, "Group #3");

        newHButton = hbuttonObjectPool.GetObject();
        newHButton.transform.SetParent(contentPanel);
        HButton = newHButton.GetComponent<HighlightButton>();
        HButton.SetWorkerMenu(this); 

        DrawMainMenu = false;
    }

    //Draws buttons for every worker in the Persons array
    private void AddWorkerButtons()
    {
        foreach (Person p in Starter.Persons)
            {
                if (!(AddedPersons.Contains(p)))
                {
                    GameObject newButton = buttonObjectPool.GetObject();
                    newButton.transform.SetParent(contentPanel);

                    WorkerButton workButton = newButton.GetComponent<WorkerButton>();
                    workButton.Setup(p, this);
 
                    AddedPersons.Add(p);
                    WorkerButtons.Add(newButton);
                }
            }
    }

    //Clear the list of workers if it exists otherwise a bool is set to draw the next batch of workers.
    public void ListWorkersMenu()
    {        
        if (AddedPersons.Any())
        {
            foreach (GameObject Button in WorkerButtons)
            {
                buttonObjectPool.ReturnObject(Button);
            }
            AddedPersons.Clear();
            WorkerButtons.Clear();
            DrawListWorkers = false;
        } else{
            DrawListWorkers = true;
        }
        
    }

    public void ReturnToMainMenu()
    {
        DrawMainMenu = true;
        DrawListWorkers = false;
    }

    public void FixedUpdate()
    {
        RefreshDisplay();
    }
}