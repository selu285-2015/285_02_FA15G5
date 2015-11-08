using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour {

	//movement speed variables
	private float stamina;
	public float totalStamina = 5;
	public float walkSpeed = 5f;
	public float runSpeed = 7.5f;
	private float movementSpeed;
	private bool sprint;

	//movement key variables
	float vertical;
	float horizontal;

	//mouse/view variables
	public float mouseSensitivity = 5.0f;
	float mouseHorizontal;
	public float viewRange = 70.0f;
	float verticalStart = 0;	//had to look this up, using this variable sets the Quaternion.Euler (from center screen, 360 degree view angle) to count from 0 to -1 or 1 as you move the mouse up/down, rather than from 0 to 1 and 0 to 359

	private CharacterController controller;

	//simple method for setting sprint true or false
	void sprinting(bool isSprinting) {
		sprint = isSprinting;
		if (sprint)
			movementSpeed = runSpeed;
		else
			movementSpeed = walkSpeed;
	}


	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;

		controller = GetComponent<CharacterController> ();
		movementSpeed = walkSpeed;
		stamina = totalStamina;
	}


	void Update () {
		//Sprinting / stamina system
		if (Input.GetKeyDown (KeyCode.LeftShift) && (stamina > totalStamina / 2)) {    //I set this to not be able to sprint if less than half stamina
			sprinting (true);
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			sprinting (false);
		}
		if (sprint) {
			stamina -= Time.deltaTime;	//stamina decreases at a rate of 1 per second
			if (stamina < 0) {
				stamina = 0;
				sprinting (false);
			}
		} 
		else if (stamina < totalStamina)
			stamina += Time.deltaTime * 0.75f; //stamina increases at 3/4 stamina per second

		//movement (with keys/joystick)
		vertical = Input.GetAxis ("Vertical") * movementSpeed;
		horizontal = Input.GetAxis ("Horizontal") * movementSpeed;

		Vector3 speed = new Vector3 (horizontal, 0, vertical);

		//mouse look
		mouseHorizontal = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, mouseHorizontal, 0);

		verticalStart -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalStart = Mathf.Clamp (verticalStart, -viewRange, viewRange);  				//this limits your y values to be between verticalStart (which is 0) to -viewRange (which is a public variable--I use 70) and viewRange  This means you can only go from 0 to -70 or 0 to 70
		Camera.main.transform.localRotation = Quaternion.Euler (verticalStart, 0, 0); 		//I think this means that your Y rotation can be used in 3d space local to your character--I looked up how to do this part and am not 100% on specifics

		speed = transform.rotation * speed;
		controller.SimpleMove (speed);


	}
}
