﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that sap betwin cameras and set the sean that shows.
/// <para>Camera links in the difrent cameras</para>
/// <para>GameObjeks is the diftent floars f1 = floar 1 f2 = floar 2</para>
/// </summary>
public class cameraSwitch : MonoBehaviour {

//read the objekts to be controld
    [SerializeField]
    Camera startCam;
    [SerializeField]
    Camera cam1;
    [SerializeField]
    Camera cam2;
    [SerializeField]
    Camera cam3;
    [SerializeField]
    Camera cam4;
    [SerializeField]
    Camera cam5;
    [SerializeField]
    GameObject f1;
    [SerializeField]
    GameObject f2;
    

    private Camera[] cams = new Camera[6];

//variabel top control the switching
    private KeyCode camSap = KeyCode.Tab;
    private bool camSapBool = true;
    private int camNr = 0;

    private KeyCode seanSelect = KeyCode.F;
    private bool seanSelectBoll = true;
    private int seanSet = 0;

	// set upp stat and add the cams to a array
	void Start () {

        startCam.GetComponent<Camera>().enabled = true;
        cam1.GetComponent<Camera>().enabled = false;
        cam2.GetComponent<Camera>().enabled = false;
        cam3.GetComponent<Camera>().enabled = false;
        cam4.GetComponent<Camera>().enabled = false;
        cam5.GetComponent<Camera>().enabled = false;

        f1.SetActive(true);
        f2.SetActive(true);

        cams[0] = startCam;
        cams[1] = cam1;
        cams[2] = cam2;
        cams[3] = cam3;
        cams[4] = cam4;
        cams[5] = cam5;
    }
	
	// Update is called once per frame
	void Update () {
	
        //chek for key prsess
        if (Input.GetKey(camSap))
        {
            if (!camSapBool) toggel(camSap);
        }
        else camSapBool = false;

        if (Input.GetKey(seanSelect))
        {
            if (!seanSelectBoll) toggel(seanSelect);
        }
        else seanSelectBoll = false;
    }

    /// <summary>
    /// toggel the to next cam or change aktive sean
    /// </summary>
    /// <param name="key"> chek if it is cam or sen theat is about to change</param>
    void toggel(KeyCode key)
    {
        if (key == camSap)
        {
            camSapBool = true;
            camNr = (camNr + 1) % cams.Length;
            change();
        }
        else if (key == seanSelect)
        {
            seanSelectBoll = true;
            seanSet = (seanSet + 1) % 3;
            change();
        }
        
    }

    // change the live setings sow the korekt sean and camera ar aktive
    void change()
    {
        for (int i = 0; i < cams.Length; i++)
        {
            if (i == camNr)
            {
                cams[i].GetComponent<Camera>().enabled = true;
              
                
            }
            else cams[i].GetComponent<Camera>().enabled = false;
        }
        switch (seanSet)
        {
            case 0:
                f1.SetActive(true);
                f2.SetActive(true);
                break;
            case 1:
                f1.SetActive(true);
                f2.SetActive(false);
                break;
            case 2:
                f1.SetActive(false);
                f2.SetActive(true);
                break;
            default:
                seanSet = 0;
                break;
        }
    }
}
