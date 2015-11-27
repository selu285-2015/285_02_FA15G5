using UnityEngine;
using System.Collections;

public class TriggerWaterphone : MonoBehaviour {

    public AudioSource waterphoneSound1;

    int time;

	// Use this for initialization
	void Start () {
        waterphoneSound1 = GetComponent<AudioSource>();
        StartCoroutine("PlayTime");
	}

    private IEnumerator PlayTime(){
        while(true){
            yield return new WaitForSeconds(1);
			time++;
            int chooseSound = Random.Range(30, 60);
            if(time % 47 == 0){ 
                waterphoneSound1.Play();
            }
        }
    }

}
