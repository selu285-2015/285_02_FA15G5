using UnityEngine;
using System.Collections;

public class FirstItemPickUp : MonoBehaviour {

	bool message = false;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

	void OnTriggerEnter(Collider player ) {

		if(player.gameObject.name == "Player")
		{
			message = true;
		}

	}

	void OnTriggerExit(Collider player) {
		
		message = false;
		
	}

	void OnGUI() {
		if(message == true){
			GUILayout.Box("This is a lever. Left click to pick it up.");
			GameObject effect = GameObject.Find("Cylinder");
			if(Input.GetMouseButtonDown(0)){
				Destroy(effect);
                player.GetComponent<PlayerInventory>().SetInventory(true);
			}
		}
	}

}
