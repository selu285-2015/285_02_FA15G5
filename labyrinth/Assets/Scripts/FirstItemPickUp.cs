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
			GUILayout.Box("There is no lever yet. Left click to pick up the item.");
			GameObject effect = GameObject.Find("Capsule");
			if(Input.GetMouseButtonDown(0)){
				Destroy(effect);
                player.GetComponent<PlayerInventory>().SetInventory(true);
			}
		}
	}

}
