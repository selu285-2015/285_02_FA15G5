using UnityEngine;
using System.Collections;

public class FirstItemPickUp : MonoBehaviour {

	bool message = false;
    GameObject player;
    GameObject leverSpot;
    GUIStyle style = new GUIStyle();
    public Font myFont;

    void Start()
    {
        player = GameObject.Find("Player");
        leverSpot = GameObject.Find("Lever Trigger");
        style.fontSize = 20;
        style.normal.textColor = Color.white;
        style.font = myFont;
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
			GUILayout.Box("This is a lever piece. Left click to pick it up.", style);
			GameObject effect = GameObject.Find("Lever Piece");
			if(Input.GetMouseButtonDown(0)){
				Destroy(effect);
                player.GetComponent<PlayerInventory>().SetInventory(true);
                leverSpot.GetComponent<LeverTrigger>().PickedUpLeverPiece(true);
			}
		}
	}

}
