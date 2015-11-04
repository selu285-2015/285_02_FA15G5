using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

    int deaths;
    int time;
    int winTime;

	// Use this for initialization
	void Start () {
        deaths = RoundEnd.deathCount;
        time = RoundEnd.totalTime + GameEnd.totalTime;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUILayout.Box("deaths: " + deaths + " time: " + time);
    }
}
