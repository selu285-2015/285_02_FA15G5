using UnityEngine;
using System.Collections;

public class FadeStart : MonoBehaviour {

    float timer = 5.0f;
    Color change;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;

        if(timer > 0)
        {
            
        }

        if(timer <= 0)
        {
            Application.LoadLevel("main");
        }
	}
}
