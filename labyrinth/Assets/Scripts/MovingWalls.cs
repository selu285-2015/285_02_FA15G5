using UnityEngine;
using System.Collections;

public class MovingWalls : MonoBehaviour {

    bool isMoving;
    GameObject wall;
    AudioSource wallSound;

	// Use this for initialization
	void Start () {
        isMoving = false;
        wall = GameObject.Find("Moving Wall");
        wallSound = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	    if(isMoving && wallSound.isPlaying){
            wall.transform.Translate(0,Time.deltaTime * -.9f,0);
        }
        else
        {
            wall.transform.Translate(0,0,0);
        }
	}

    public void IsMoving(bool leverPulled)
    {
        isMoving = leverPulled;
        wallSound.Play();
    }
}
