using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        Application.LoadLevel("main");
    }
	
	// Update is called once per frame
	public void Exit () {
        Application.Quit();
    }
}
