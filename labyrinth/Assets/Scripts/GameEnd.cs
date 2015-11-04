using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {
    public GameObject player;

    public static int totalTime = 0;
    public RoundEnd deathTimes;

	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter(Collider player){

        if (player.gameObject.name == "Player")
        {
            Application.LoadLevel("HighScores");
            totalTime = deathTimes.timeInSecs;
        }

    }

}
