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
        style.fontSize = 25;
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
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4, (Screen.height) / 4),
                                "    This is a lever, \n left-click to pick it up",
                                style);

            GameObject effect = GameObject.Find("Lever Piece");
			if(Input.GetMouseButtonDown(0)){
				Destroy(effect);
                player.GetComponent<PlayerInventory>().SetInventory(true);
                leverSpot.GetComponent<LeverTrigger>().PickedUpLeverPiece(true);
			}
		}
	}

}
