using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int time = 0;
	public int seconds = 0;
	public int minutes = 0;
	
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("PlayTime");
	}
	
	private IEnumerator PlayTime()
	{
		while (true) 
		{
			yield return new WaitForSeconds(1);
			time += 1;
			seconds = (time % 60);
			minutes = (time / 60) % 60;
		}
	}
	
	void OnGUI ()
	{
		GUI.contentColor = Color.red;
		GUI.Label (new Rect (Screen.width-100, 100, 200, 100),"<size=20>"+ minutes.ToString() + ":" + seconds.ToString()+ "</size>");
	}
}
