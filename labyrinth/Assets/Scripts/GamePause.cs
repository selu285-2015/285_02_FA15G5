using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
    bool pause;

	// Use this for initialization
	void Start () {
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            if (pause == true)
            {
                Time.timeScale = 0f;
            }
            else
                Time.timeScale = 1;
        }

	}

    void OnGUI()
    {
        if(pause == true)
        {
            GUILayout.Box("Game Paused");
        }
    }
}
