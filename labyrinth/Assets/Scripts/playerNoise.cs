using UnityEngine;
using System.Collections;

public class playerNoise : MonoBehaviour
{
    public CharacterController controller;
    public SphereCollider sphere;
    public Transform minotaur;
    public Transform player;

    private float time;
    private float dist;

    void Update()
    {
        dist = Vector3.Distance(minotaur.position, player.position);
        sphere.transform.localScale = new Vector3((5 + (40/ dist)) * controller.velocity.magnitude, (5 + (40 / dist)) * controller.velocity.magnitude, 1);  // this looks ugly, but it makes the noise cirlce expand as the minotaur gets closer and also when the player moves

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Minotaur")
        {        
            if (controller.velocity.magnitude >= 7.4f)
            {
                MinoAI.playerRadiusToSearch = dist / 3;
            }
            else if (controller.velocity.magnitude >= 4.9f && controller.velocity.magnitude < 7.4f)
            {
                MinoAI.playerRadiusToSearch = dist / 2;
            }
            else
            {
                MinoAI.playerRadiusToSearch = dist / 1.3f;
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        time += Time.deltaTime;
        if(time > 1.0f)
        {
            if (collider.tag == "Minotaur")
            {
                if (controller.velocity.magnitude >= 7.4f)
                {
                    MinoAI.playerRadiusToSearch = dist / 3;
                    if(dist < 6.0f)
                    {
                        MinoAI.minoState = MinoAI.State.SIGHTED;
                    }
                }

                else if (controller.velocity.magnitude >= 4.9f && controller.velocity.magnitude < 7.4f)
                {
                    MinoAI.playerRadiusToSearch = dist / 2;
                }

                else if (controller.velocity.magnitude < 4.9 )
                {
                    MinoAI.playerRadiusToSearch = dist;
                }
            }
            
            time = 0;
        }
    }
}