using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public Button resume;
    public Button exit;
    GameObject player;
    

    void Start () {
        
        resume = resume.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        player = GameObject.Find("Player");
    }
	

	public void ResumeGame () {
        player.GetComponent<GamePause>().SetShowMenuOnClick(false);
	}

    public void ExitGame()
    {
        Application.LoadLevel(0);
    }
}
