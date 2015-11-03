using UnityEngine;
using System.Collections;

public class TriggerWaterphone : MonoBehaviour {

    AudioSource waterphoneSound;

	// Use this for initialization
	void Start () {
        waterphoneSound = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter(Collider player) {
        if (player.tag == "Player")
        {
            waterphoneSound.Play();
        }
	}

}
