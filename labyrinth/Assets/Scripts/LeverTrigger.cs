using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {

    bool hasLeverPiece;
    bool message;
    GUIStyle style = new GUIStyle();
    GameObject player;
    GameObject wall;
    public Font myFont;
    GameObject lever;
    bool isVisible;
    GameObject LnC;

	// Use this for initialization
	void Start () {
        lever = GameObject.Find("ConnectionPiece");
        LnC = GameObject.Find("Lever_and_Contraption");
        isVisible = false;
        lever.SetActive(false);
        hasLeverPiece = false;
        message = false;
        style.fontSize = 25;
        style.font = myFont;
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
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4, (Screen.height) / 4),
                                "Left-click to place the lever \n   and activate the device",
                                style);
            if (Input.GetMouseButtonDown(0))
            {
                LnC.GetComponent<AnimationControllerScript>().StartAnimation(true);
                isVisible = true;
                lever.SetActive(true);
                player.GetComponent<PlayerInventory>().SetInventory(false);
                wall.GetComponent<MovingWalls>().IsMoving(true);
                Destroy(this);
            }
        }
    }
}
