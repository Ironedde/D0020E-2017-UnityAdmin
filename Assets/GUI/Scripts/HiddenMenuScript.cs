using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenMenuScript : MonoBehaviour {
    private CanvasGroup cgroup;

    // Use this for initialization
    void Start () {
        cgroup = GetComponent<CanvasGroup>();
    }

    public void onClick()
    {
        if (cgroup.alpha > 0.0f)
        {
            cgroup.alpha = 0.0f;
            cgroup.interactable = false;
        }
        else
        {
            cgroup.alpha = 1.0f;
            cgroup.interactable = true;
        }
    }
}
