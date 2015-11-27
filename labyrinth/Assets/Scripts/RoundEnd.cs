﻿using UnityEngine;
using System.Collections;

public class RoundEnd : MonoBehaviour {

    public static int deathCount = 0;
    public static int totalTime = 0;
    public int time = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int timeInSecs;
    string display;
    GUIStyle style = new GUIStyle();
    public Font myFont;
    public int fontS;

    void OnCollisionEnter(Collision attacked) {

		if(attacked.gameObject.name == "Player")
		{
			Application.LoadLevel(1);
            deathCount++;
            totalTime = totalTime + timeInSecs;
		}

	}
	
     void Start () 
	{
        style.fontSize = fontS;
        style.font = myFont;
        style.normal.textColor = Color.red;
		StartCoroutine ("PlayTime");
	}

	private IEnumerator PlayTime()
	{
		while (true) 
		{
			yield return new WaitForSeconds(1);
			time++;
            timeInSecs++;
			seconds = (time % 60);
			minutes = (time / 60) % 60;
            display = string.Format("{0:0}:{1:00}", minutes, seconds);
		}
	}
	
}

