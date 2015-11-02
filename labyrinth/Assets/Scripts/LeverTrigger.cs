using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {

    bool hasLeverPiece;
    bool message;
    GUIStyle style = new GUIStyle();
    GameObject player;
    GameObject wall;

	// Use this for initialization
	void Start () {
        hasLeverPiece = false;
        message = false;
        style.fontSize = 20;
        style.normal.textColor = Color.white;
        player = GameObject.Find("Player");
        wall = GameObject.Find("Moving Wall");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            message = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        message = false;
    }

    public void PickedUpLeverPiece(bool hasPiece)
    {
        hasLeverPiece = hasPiece;
    }

    void OnGUI()
    {
        if(message == true && hasLeverPiece == true){
            GUILayout.Box("Left click to place the lever piece into the wall and activate the lever.", style);
            if (Input.GetMouseButtonDown(0))
            {
                player.GetComponent<PlayerInventory>().SetInventory(false);
                wall.GetComponent<MovingWalls>().IsMoving(true);
            }
        }
    }
}
