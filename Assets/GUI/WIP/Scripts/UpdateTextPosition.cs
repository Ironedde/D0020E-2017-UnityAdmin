using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextPosition : MonoBehaviour {
    private Text gtext;

	// Use this for initialization
	void Start () {
       gtext = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        TextAsset txtdata = Resources.Load("PositionFile") as TextAsset;
        string PositionString = txtdata.text;
        gtext.text = PositionString;
    }
}
