using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndCredits : MonoBehaviour {

    float speed = 50f;
    public Text team;
    public Text congratulations;
    public Text continueMessage;
    bool move;

	// Use this for initialization
	void Start () {
        move = true;
        team = team.GetComponent<Text>();
        congratulations = congratulations.GetComponent<Text>();
        continueMessage = continueMessage.GetComponent<Text>();
        congratulations.text = "";
        continueMessage.text = "";
}
	
	
	void Update () {
        if(move == true) {
            team.transform.Translate(Vector3.up * Time.deltaTime * speed);
            if(team.transform.position.y > Screen.height + 350)
            {
                move = false;
            }
        }
        else { 
            team.transform.Translate(Vector3.zero);
            congratulations.text = "Thanks for playing!";
            StartCoroutine(BlinkingText());
        }
    }

    public IEnumerator BlinkingText()
    {
        bool showMessage = true;
        while (showMessage)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("Start_Screen");
            }
            continueMessage.text = "";
            yield return new WaitForSeconds(.5f);
            continueMessage.text = "Left Click to Continue";
            yield return new WaitForSeconds(.5f);
        }
    }

}
