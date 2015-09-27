using UnityEngine;
using System.Collections;

public class MinoAI : MonoBehaviour {

	//This is likely to be reworked 5 times over or scrapped.  It's still a work in progress and has a few big missing features.

	private bool minoOn;  // if, for some reason, we want to turn the mino AI off -- maybe for a paused state

	// Objects we need
	public NavMeshAgent minotaur;
	public Transform playerLocation;
	public GameObject player;
	
	// Minotaur speed variables
	public float minoWalkSpeed;
	public float minoRunSpeed;
	public float minoChargeSpeed;

	// Time variables for Investigate mode
	public float investigateTime = 20.0f;
	private float time;

	// Sight-related variables for investigate mode
	public float fieldOfView = 60.0f;
	public float sightRange = 15.0f;
	public float minoEyeHeight;

	//AI states for different behavior/systems in play
	public enum State {
		FIND,
		INVESTIGATE,
		SIGHTED
	}
	public State minoState;

	//Finite State Machine allows us to change states as needed
	IEnumerator FiniteStateMachine() {
		while (minoOn) {
			switch (minoState) {  //the switch statement structure works nicely here
				case State.FIND:
					Find();
					break;
				case State.INVESTIGATE:
					Investigate();
					break;
				case State.SIGHTED:
					Sighted();
					break;
			}
			yield return null;
		}
	}

	//Find() is only to get the Minotaur near the player
	void Find() {
		minotaur.speed = minoChargeSpeed;
		minotaur.destination = playerLocation.position;
	}

	//Investigate() is enabled when Mino is near the player.  Mino needs "sight" now to find the player.
	//This functionality isn't quite implemented just yet--need to figure out random searching/wandering
	void Investigate() {
		Debug.DrawRay(transform.position + Vector3.up * minoEyeHeight, transform.forward * sightRange, Color.red);  //for visual reference
		Debug.DrawRay(transform.position + Vector3.up * minoEyeHeight, (transform.forward + (transform.right / 10)) * sightRange, Color.red);
		Debug.DrawRay(transform.position + Vector3.up * minoEyeHeight, (transform.forward - (transform.right / 10)) * sightRange, Color.red);

		RaycastHit hit;

		//draws a raycast from the mino's postion at eye height; it's direction is forward; using hit; it is sightRange in length 
		if (Physics.Raycast (transform.position + Vector3.up * minoEyeHeight, transform.forward, out hit, sightRange)) {
			if (hit.collider.gameObject.tag == "Player") {
				minoState = MinoAI.State.SIGHTED;
				player = hit.collider.gameObject;
			}
		}
		if (Physics.Raycast (transform.position + Vector3.up * minoEyeHeight, (transform.forward + (transform.right / 10)), out hit, sightRange)) {
			if (hit.collider.gameObject.tag == "Player") {
				minoState = MinoAI.State.SIGHTED;
				player = hit.collider.gameObject;
			}
		}
		if (Physics.Raycast (transform.position + Vector3.up * minoEyeHeight, (transform.forward - (transform.right / 10)), out hit, sightRange)) {
			if (hit.collider.gameObject.tag == "Player") {
				minoState = MinoAI.State.SIGHTED;
				player = hit.collider.gameObject;
			}
		}

		time += Time.deltaTime;  // time variable increments every 1 second
		minotaur.speed = minoWalkSpeed;

		if (time >= investigateTime) {  //if investigate time is over, switch back to find mode to see if we need to catch up to the player
			minoState = MinoAI.State.FIND;
			time = 0;
		}
	}

	//Sighted() is for when the Mino spots the player, I'm not sure it's needed right now since Find() does almost literally the same thing
	void Sighted() {
		minotaur.speed = minoRunSpeed;
		minotaur.destination = playerLocation.position;  // filler until I figure out how to flesh out walk/run/charge mechanics
	}


	//This is supposed to switch the Minotaur into Investigate mode when he's inside the attached sphere collider's radius
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player")
			minoState = MinoAI.State.INVESTIGATE;
	}

	void Start () {
		minotaur = GetComponent<NavMeshAgent> ();

		minoState = MinoAI.State.FIND;  // initialized to find player first

		minoOn = true;

		StartCoroutine ("FiniteStateMachine");
	}

}
