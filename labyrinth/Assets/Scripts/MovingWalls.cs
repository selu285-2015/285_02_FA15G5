using UnityEngine;
using System.Collections;

public class MovingWalls : MonoBehaviour {

    bool isMoving;
    GameObject wall;
    AudioSource wallSound;
    public float wallSpeed;
    public ParticleSystem particle;
    GameObject LnC;
    Animator animator;
    

	// Use this for initialization
	void Start () {
        isMoving = false;
        wall = GameObject.Find("Moving Wall");
        wallSound = GetComponent<AudioSource>();
        LnC = GameObject.Find("Lever_And_Contraption");
        animator = LnC.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(isMoving && wallSound.isPlaying){
            wall.transform.Translate(0,Time.deltaTime * wallSpeed,0);
        }
        else
        {
            wall.transform.Translate(0,0,0);
        }
        if (!(wallSound.isPlaying))
        {
            particle.Stop();
            LnC.GetComponent<AnimationControllerScript>().StartAnimation(false);
        }
	}

    public void IsMoving(bool leverPulled)
    {
        isMoving = leverPulled;
        wallSound.Play();
        particle.Play();
    }
}
