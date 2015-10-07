using UnityEngine;
using System.Collections;

public class CharMovement : MonoBehaviour {

	CharacterController Player;
	Vector3 Walking;
	float playerSpeed = 10.0f;

	// Use this for initialization
	void Start () {

		Player = GetComponent<CharacterController>();
		transform.position = new Vector3(0,0,0);
		Walking = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
			
			if (Input.GetKey (KeyCode.W)) {
				Walking = Vector3.forward;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;
			}
		
			if (Input.GetKeyUp (KeyCode.W)) {
				Walking = Vector3.zero;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;
			}
		
			if (Input.GetKey (KeyCode.A)) {
				Walking = Vector3.left;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;
			}
		
			if (Input.GetKeyUp (KeyCode.A)) {
				Walking = Vector3.zero;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;
			}
		
			if (Input.GetKey (KeyCode.S)) {
				Walking = Vector3.back;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;
			}
		
			if (Input.GetKeyUp (KeyCode.S)) {
				Walking = Vector3.zero;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;
			}
		
			if (Input.GetKey (KeyCode.D)) {
				Walking = Vector3.right;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;
			}
		
			if (Input.GetKeyUp (KeyCode.D)) {
				Walking = Vector3.zero;
				Walking = transform.TransformDirection (Walking);
				Walking *= playerSpeed;

			}
			
			
			Player.Move(Walking * Time.deltaTime);
			
	}
}
