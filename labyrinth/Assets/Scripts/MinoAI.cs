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
public class MinoAI : MonoBehaviour
{

    // This is likely to be reworked 5 times over or scrapped.  It's still a work in progress and has a few big missing features.

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
    public float investigateTime = 13.0f;
    private float time;

    // Sight-related variables for Investigate mode
    public float fieldOfView = 60.0f;
    public float sightRange = 15.0f;
    public float minoEyeHeight;

    // Variables for player searching for Investigate mode
    private bool playerInTrigger = false;
    public float playerRadiusToSearch = 5.0f;
    private float xPlayerRadiusToSearch;
    private float zPlayerRadiusToSearch;
    private float distanceToPoint;
    private float distanceToPlayer;
    private Vector2 rand;
    private Vector3 newDestination;

    // AI states for different behavior/systems in play
    public enum State
    {
        FIND,
        INVESTIGATE,
        SIGHTED
    }
    public State minoState;

    // Finite State Machine allows us to change states as needed
    IEnumerator FiniteStateMachine()
    {
        while (minoOn)
        {
            switch (minoState)  // the switch statement structure works nicely here
            {
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

    // Find() is only to get the Minotaur near the player
    void Find()
    {
        minotaur.speed = minoChargeSpeed;
        minotaur.destination = playerLocation.position;
    }

    // Investigate() is enabled when Mino is near the player.  Mino needs "sight" now to find the player.
    // This functionality isn't quite implemented just yet--need to figure out random searching/wandering
    void Investigate()
    {
        minotaur.speed = minoWalkSpeed;

        Debug.DrawRay(transform.position + Vector3.up * minoEyeHeight, transform.forward * sightRange, Color.red);  //for visual reference
        Debug.DrawRay(transform.position + Vector3.up * minoEyeHeight, (transform.forward + (transform.right / 10)) * sightRange, Color.red);
        Debug.DrawRay(transform.position + Vector3.up * minoEyeHeight, (transform.forward - (transform.right / 10)) * sightRange, Color.red);

        RaycastHit hit;

        // draws a raycast from the mino's postion at eye height; it's direction is forward; using hit; it is sightRange in length 
        if (Physics.Raycast(transform.position + Vector3.up * minoEyeHeight, transform.forward, out hit, sightRange))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                minoState = MinoAI.State.SIGHTED;
                player = hit.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * minoEyeHeight, (transform.forward + (transform.right / 10)), out hit, sightRange))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                minoState = MinoAI.State.SIGHTED;
                player = hit.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * minoEyeHeight, (transform.forward - (transform.right / 10)), out hit, sightRange))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                minoState = MinoAI.State.SIGHTED;
                player = hit.collider.gameObject;
            }
        }

        distanceToPoint = Vector3.Distance(newDestination, transform.position);
        if (distanceToPoint <= 5)
        {
            searchForPlayer();  // find a new position to search if mino is within 5 units of point
        }

        distanceToPlayer = Vector3.Distance(playerLocation.position, transform.position);
        if (distanceToPlayer >= 80)
        {
            minoState = MinoAI.State.FIND;  // find the player if he strays too far away too quickly
        }

        if (distanceToPlayer <= 3)
        {
            minoState = MinoAI.State.SIGHTED; // find the player if he's out of our sight but really close (no corner cheesing)
        }

        time += Time.deltaTime;  // time variable increments every 1 second

        if (time >= investigateTime)  //if investigate time is over and player is out of mino radius, switch back to find mode to catch up to the player
        {
            if (playerInTrigger == false)
                minoState = MinoAI.State.FIND;
            time = 0;
        }
    }

    // Sighted() is for when the Mino spots the player, I'm not sure it's needed right now since Find() does almost literally the same thing
    void Sighted()
    {
        minotaur.speed = minoRunSpeed;
        minotaur.destination = playerLocation.position;  // filler until I figure out how to flesh out walk/run/charge mechanics
    }


    // This is supposed to switch the Minotaur into Investigate mode when he's inside the attached sphere collider's radius
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            minoState = MinoAI.State.INVESTIGATE;
            searchForPlayer();
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            playerInTrigger = false;
        }
    }

    // Very rough way to search for player; pick a point in a circle, add x, y of point to x, z of player position (essentially picking a random point on a circle around player)
    void searchForPlayer()
    {
        rand = Random.insideUnitCircle * playerRadiusToSearch;
        xPlayerRadiusToSearch = rand.x;
        zPlayerRadiusToSearch = rand.y;

        newDestination = new Vector3((playerLocation.position.x + xPlayerRadiusToSearch), 0, (playerLocation.position.z + zPlayerRadiusToSearch));
        minotaur.destination = newDestination;
        Debug.DrawRay(newDestination, Vector3.up * 15, Color.yellow, 15.0f);  // visual reference for points chosen, they last 15 seconds
    }

    void Start()
    {
        minotaur = GetComponent<NavMeshAgent>();

        minoState = MinoAI.State.FIND;  // initialized to find player first

        minoOn = true;

        StartCoroutine("FiniteStateMachine");
    }
}