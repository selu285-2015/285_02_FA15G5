using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}

    void OnTriggerEnter(Collider player){

        if (player.gameObject.name == "Player")
        {
            Application.LoadLevel("Ending");
        }

    }

}
