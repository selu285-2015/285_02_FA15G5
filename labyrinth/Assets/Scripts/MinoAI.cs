using UnityEngine;
using System.Collections;

public class MinoAI : MonoBehaviour
{

    // This is likely to be reworked 5 times over or scrapped.  It's still a work in progress and has a few big missing features.

    private bool minoOn;  // if, for some reason, we want to turn the mino AI off -- maybe for a paused state

    // Objects we need
    public NavMeshAgent minotaur;
    private Transform playerLastLocation;
    public Transform playerLocation;
    public GameObject player;
    public Transform[] spawnPoints;
    public Animation animation;

    // Misc variables
    public float minoWalkSpeed;
    public float minoRunSpeed;
    public float minoChargeSpeed;
    public float lastKnown = 4.0f;
    private float trackCooldown;
    private int randomSpawnPoint;

    // Time variables for Investigate mode
    public float investigateTime = 13.0f;
    private float time;

    // Sight-related variables for Investigate mode
    public float fieldOfView = 60.0f;
    public float sightLength = 15.0f;
    public float minoEyeHeight;
    public float visionRange = 45.0f;
    private float visionAngle;

    // Variables for player searching for Investigate mode
    private bool playerInTrigger = false;
    static public float playerRadiusToSearch = 13.0f;
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
    static public State minoState;

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
        minotaur.destination = playerLastLocation.position;
    }

    // Investigate() is enabled when Mino is near the player.  Mino needs "sight" now to find the player.
    // This functionality isn't quite implemented just yet--need to figure out random searching/wandering
    void Investigate()
    {
        minotaur.speed = minoWalkSpeed;

        visionAngle = Vector3.Angle((playerLastLocation.position - transform.position), transform.forward);
        RaycastHit hit;
        if (visionAngle < visionRange)
        {
            Debug.DrawRay(transform.position + Vector3.up * minoEyeHeight, (playerLastLocation.position - transform.position), Color.cyan);
            if (Physics.Raycast(transform.position + Vector3.up * minoEyeHeight, (playerLastLocation.position - transform.position), out hit, sightLength))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    minoState = MinoAI.State.SIGHTED;
                    player = hit.collider.gameObject;
                }
            }
        }


        distanceToPoint = Vector3.Distance(newDestination, transform.position);
        if (distanceToPoint <= 5)
        {
            searchForPlayer();  // find a new position to search if mino is within 5 units of point
        }

        distanceToPlayer = Vector3.Distance(playerLastLocation.position, transform.position);
        if (distanceToPlayer >= 80)
        {
            minoState = MinoAI.State.FIND;  // find the player if he strays too far away too quickly
        }

        if (distanceToPlayer <= 3.5f)
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
        minotaur.destination = playerLastLocation.position;  // filler until I figure out how to flesh out walk/run/charge mechanics
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

        newDestination = new Vector3((playerLastLocation.position.x + xPlayerRadiusToSearch), 0, (playerLastLocation.position.z + zPlayerRadiusToSearch));
        minotaur.destination = newDestination;
        Debug.DrawRay(newDestination, Vector3.up * 15, Color.yellow, 15.0f);  // visual reference for points chosen, they last 15 seconds
    }

    void Start()
    {
        animation.Play();

        minotaur.enabled = false;

        randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        transform.position = new Vector3(spawnPoints[randomSpawnPoint].position.x, spawnPoints[randomSpawnPoint].position.y, spawnPoints[randomSpawnPoint].position.z);

        minotaur.enabled = true;

        playerLastLocation = playerLocation;

        minotaur = GetComponent<NavMeshAgent>();

        minoState = MinoAI.State.FIND;  // initialized to find player first

        minoOn = true;

        StartCoroutine("FiniteStateMachine");
    }

    void Update()
    {
        trackCooldown += Time.deltaTime;
        if (lastKnown < trackCooldown)
        {
            trackCooldown = 0;
            playerLastLocation = playerLocation;
        }
    }
}