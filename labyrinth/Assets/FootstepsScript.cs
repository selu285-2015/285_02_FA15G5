using UnityEngine;
using System.Collections;

public class FootstepsScript : MonoBehaviour {
    GameObject player;
    GameObject footsteps;
    public CharacterController controller;
    public AudioSource footstep;
    float time;
	// Use this for initialization
	void Start () {
        controller = player.GetComponent<CharacterController>();
        footstep = footsteps.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (!(controller.velocity == Vector3.zero))
        {
            if (!(footstep.isPlaying))
            {
                footstep.Play();
            }
            
        }
        else
        {
            footstep.Stop();
        }
	}
}
