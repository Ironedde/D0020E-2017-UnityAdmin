using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Models;


public class HighlightButton : MonoBehaviour {
    public Button HButton;
    public Text HText;
    private ActiveWorkersList MenuList;  
    public enum State
    {
        All = 0,
        GroupOne = 1,
        GroupTwo = 2,
        GroupThree = 3,
        MainMenu = 4,
        WorkerMenu = 5
    }
    State CurrentState;

    void Start () {
	}
    
    //Defines All & Group buttons behaviour
    public void SetState(State state, string str)
    {
        CurrentState = state;
        HText.text = str;
    }

    //Defines List Workers button behaviour
    public void SetWorkerMenu(ActiveWorkersList ActiveMenuList)
    {
        MenuList = ActiveMenuList;
        CurrentState = State.WorkerMenu;
        HText.text = "List Workers";
    }

    /*
    //Optional button to return to a previous menu state
    public void SetReturnToMainMenu(ActiveWorkersList ActiveMenuList)
    {
        MenuList = ActiveMenuList;
        CurrentState = State.MainMenu;
        HText.text = "Return to Main Menu";
    }
    */

    //Activates the light and sets a color for every worker in a workgroup, otherwise it deactivates the light.
    private void paintWorkgroup(int workgroupID, Color lightColor)
    {
        foreach (Person p in Starter.Persons)
        {
            Light component = p.gameobject.transform.Find("Area Light").GetComponent<Light>();
            if (p._workgroupID == workgroupID)
            {
                component.range = 15;
                component.color = lightColor;
            }
            else
            {
                component.range = 0;
            }
        }
    }

    //On Click functionality
    public void HighlightHandleClick()
    {

        if (CurrentState == State.All)
        {
            foreach (Person p in Starter.Persons)
            {
                Light component = p.gameobject.transform.Find("Area Light").GetComponent<Light>();
                component.range = 15;
                component.color = new Color(1, 1, 2, 0);
            }
        }

        if (CurrentState == State.GroupOne)
        {
            paintWorkgroup(1, new Color(1, 1, 0, 1));
        }

        if (CurrentState == State.GroupTwo)
        {
            paintWorkgroup(2, new Color(1, 0, 1, 1));
        }

        if (CurrentState == State.GroupThree)
        {
            paintWorkgroup(3, new Color(1, 1, 1, 1));
        }

        if (CurrentState == State.WorkerMenu)
        {
            MenuList.ListWorkersMenu();
        }

        /*
        if (CurrentState == State.MainMenu)
        {
            MenuList.ReturnToMainMenu();
        }
        */

    }
}
