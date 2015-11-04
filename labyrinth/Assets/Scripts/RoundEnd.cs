using UnityEngine;
using System.Collections;

public class RoundEnd : MonoBehaviour {

    public static int deathCount = 0;
    public static int totalTime = 0;
    public int time = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int timeInSecs;
    string display;

	void OnCollisionEnter(Collision attacked) {

		if(attacked.gameObject.name == "Player")
		{
			Application.LoadLevel(1);
            deathCount++;
            totalTime = totalTime + timeInSecs;
            OnGUI();
		}

	}
	
     void Start () 
	{
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
            GUI.Label(new Rect(900, 4, 400, 50), "<size=30>" + "0:00" + "</size>");
        }
		GUI.Label (new Rect (900, 4, 400, 50),"<size=30>"+ display + "</size>");
        GUILayout.Box("death count = " + deathCount + "\n" + "total time = " + totalTime + "\n" + "time in secs = " + timeInSecs);
	}
}

