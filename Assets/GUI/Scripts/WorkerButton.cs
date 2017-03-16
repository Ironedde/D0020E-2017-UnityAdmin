using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class WorkerButton : MonoBehaviour {
    public Button ActiveWorkerButton;
    public Text WorkerNameText;
    public Person arbetare;
    private bool active = false;

    void Start()
    {
    }

    //Sets the text of the worker button
    public void Setup(Person currentWorker, ActiveWorkersList activeList)
    {
        arbetare = currentWorker;
        WorkerNameText.text = "Worker " + arbetare._workerID;
    }

    //On click activate the light on the worker and set a new color
    public void WorkerHandleClick()
    {
        Light arbetareLight = arbetare.gameobject.transform.Find("Area Light").GetComponent<Light>();

        if (active == false)
        {
            arbetareLight.range = 15;
            arbetareLight.color = new Color(1, 0, 0, 1);
            active = true;
        }
        else
        {
            arbetareLight.range = 0;
            active = false;
        }
        
    }
}
    