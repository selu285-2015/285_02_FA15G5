using UnityEngine;
using System.Collections;

public class AnimationControllerScript : MonoBehaviour {
    Animator animator;
    bool isMoving;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("Activated", isMoving);
	}
    public void StartAnimation(bool begin)
    {
        isMoving = begin;
    }
}
