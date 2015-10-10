using UnityEngine;
using System.Collections;

public class RoundEnd : MonoBehaviour {
	
	// Use this for initialization
	void OnCollisionEnter(Collision attacked) {

		if(attacked.gameObject.name == "Player")
		{
			Application.LoadLevel(1);
		}

	}
	
}
