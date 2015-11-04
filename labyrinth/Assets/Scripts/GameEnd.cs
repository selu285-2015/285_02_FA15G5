using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {
    public GameObject player;

    public static int totalTime;
    public RoundEnd roundTime;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}

    void OnTriggerEnter(Collider player){

        if (player.gameObject.name == "Player")
        {
            Application.LoadLevel("HighScores");
            totalTime = RoundEnd.totalTime + roundTime.timeInSecs;

        }

    }

}
