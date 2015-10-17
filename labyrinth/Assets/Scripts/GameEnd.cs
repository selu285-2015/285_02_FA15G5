using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {
    bool message = false;
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}

    void OnTriggerEnter(Collider player){

        if (player.gameObject.name == "Player")
        {
            message = true;
        }

    }

    void OnGUI(){
        if (message == true){
            GUILayout.Box("You Win!");
        }
	}
}
