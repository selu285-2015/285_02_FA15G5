using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScores : MonoBehaviour {

    int deaths;
    int time;
    int mins;
    int secs;
    string deathsString;
    string timeInMinsAndSecs;
    GUIText highScores;

	// Use this for initialization
	void Start () {
        deaths = RoundEnd.deathCount;
        time = RoundEnd.totalTime + GameEnd.totalTime;
        mins = time / 60;
        secs = time % 60;
        timeInMinsAndSecs = string.Format("{0:0}:{1:00}", mins, secs);
        PlayerPrefs.DeleteAll();
        GameOver();
	}
	
	void GameOver () { 
        if (!PlayerPrefs.HasKey("Score1"))
            {
                PlayerPrefs.SetFloat("Score1", deaths);
                PlayerPrefs.SetString("Score1", deaths.ToString());
                PlayerPrefs.SetFloat("Score1_Time", time);
                PlayerPrefs.SetString("Score1_Time", timeInMinsAndSecs);
            }

        if (!PlayerPrefs.HasKey("Score2"))
        {
            if (deaths < PlayerPrefs.GetFloat("Score1"))
            {
                PlayerPrefs.SetFloat("Score2", PlayerPrefs.GetFloat("Score1"));
                PlayerPrefs.SetString("Score2_Time", PlayerPrefs.GetString("Score1_Time"));
                PlayerPrefs.SetFloat("Score1", deaths);
                PlayerPrefs.SetString("Score1", deaths.ToString());
                PlayerPrefs.SetFloat("Score1_Time", time);
                PlayerPrefs.SetString("Score1_Time", timeInMinsAndSecs);
            }

            if (deaths == PlayerPrefs.GetFloat("Score1"))
            {

            }
        }

	}
    
    void OnGUI()
    {
            GUILayout.Box("Deaths" + "\t" + "Time" + "\n" +
                    PlayerPrefs.GetString("Score1") + "\t" + PlayerPrefs.GetString("Score1_Time") + "\n" + 
                    PlayerPrefs.GetString("Score2") + "\t" + PlayerPrefs.GetString("Score2_Time") + "\n" + 
                    PlayerPrefs.GetString("Score3") + "\t" + PlayerPrefs.GetString("Score3_Time") + "\n" + 
                    PlayerPrefs.GetString("Score4") + "\t" + PlayerPrefs.GetString("Score4_Time") + "\n" + 
                    PlayerPrefs.GetString("Score5") + "\t" + PlayerPrefs.GetString("Score5_Time") + "\n");
    }
}
