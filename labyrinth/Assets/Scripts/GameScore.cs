using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

    int deaths;
    int time;
    string timeString;
    GUIStyle style = new GUIStyle();
    public Font myFont;

	void Start () {
        deaths = RoundEnd.deathCount;
        time = RoundEnd.totalTime + GameEnd.totalTime;
        timeString = TimeToString(time);
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        style.font = myFont;
	}

    string TimeToString(int time)
    {
        int mins = time / 60;
        int secs = time % 60;
        string timeInMinsAndSecs = string.Format("{0:0}:{1:00}", mins, secs);
        return timeInMinsAndSecs;
    }

    void OnGUI()
    {
        GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4, (Screen.height) / 4),
                                "Number of deaths: " + deaths + "\n" + "Total time: " + timeString,
                                style);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(3);
        }
    }
}
