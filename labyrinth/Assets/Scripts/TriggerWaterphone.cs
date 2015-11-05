using UnityEngine;
using System.Collections;

public class TriggerWaterphone : MonoBehaviour {

    public AudioSource waterphoneSound1;
    public AudioSource waterphoneSound2;
    int time;

	// Use this for initialization
	void Start () {
        waterphoneSound1 = GetComponent<AudioSource>();
        waterphoneSound2 = GetComponent<AudioSource>();
        StartCoroutine("PlayTime");
	}

    private IEnumerator PlayTime(){
        while(true){
            yield return new WaitForSeconds(1);
			time++;
            if (time % 15 == 0){
                int chooseSound = Random.Range(1, 2);
                if(chooseSound % 2 == 1){
                    waterphoneSound1.Play();
                }else
                {
                    waterphoneSound2.Play();
                }
            }
        }
    }

}
