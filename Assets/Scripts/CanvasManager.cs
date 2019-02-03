using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Canvas").GetComponentInChildren<Text>().text = GameManager.functionsString;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
