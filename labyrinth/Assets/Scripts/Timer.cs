using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int time = 0;
	public int seconds = 0;
	public int minutes = 0;
    string display;

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
            display = string.Format("{0:0}:{1:00}", minutes, seconds);
		}
	}
	
	void OnGUI ()
	{
		GUI.contentColor = Color.red;
        if(time < 1)
        {
            GUI.Label(new Rect(900, 4, 400, 50), "<size=30>" + "0:00" + "</size>");
        }
		GUI.Label (new Rect (900, 4, 400, 50),"<size=30>"+ display + "</size>");
	}
}
