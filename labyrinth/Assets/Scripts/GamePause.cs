using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
    bool pause;
    GameObject PauseMenu;
    GameObject footsteps;
    public AudioSource footstep;

    void Start () {
        pause = false;
        PauseMenu = GameObject.Find("Pause");
        PauseMenu.SetActive(pause);
        footstep = footsteps.GetComponent<AudioSource>();

    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            pause = !pause;
            
        }

        if (pause == true)
        {
            Cursor.visible = true;
            GameObject.Find("Player").GetComponent<FirstPerson>().enabled = !pause;
            PauseMenu.SetActive(pause);
            Time.timeScale = 0;
            footstep.Stop();
        }

        if (pause == false)
        {
            Cursor.visible = false;
            GameObject.Find("Player").GetComponent<FirstPerson>().enabled = !pause;
            Time.timeScale = 1;
            PauseMenu.SetActive(pause);
        }
    }


    public void SetShowMenuOnClick(bool isClicked)
    {
        pause = isClicked;
        PauseMenu.SetActive(isClicked);
    }

}
