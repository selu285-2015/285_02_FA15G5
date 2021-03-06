﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int time;
	public int seconds = 0;
	public int minutes = 0;
    public int timeInSecs;
    string display;
    GameObject timer;
    public Font myFont;
    GUIStyle style = new GUIStyle();
    
    void Start () 
	{
        style.fontSize = 30;
        style.font = myFont;
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
	
	void OnGUI ()
	{
		GUI.contentColor = Color.red;
        if(time < 1)
        {
            GUI.Label(new Rect(900, 4, 400, 50), "<size=30>" + "0:00" + "</size>", style);
        }
		GUI.Label (new Rect (900, 4, 400, 50),"<size=30>"+ display + "</size>", style);
	}
}
