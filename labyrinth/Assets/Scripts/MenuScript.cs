using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public Button start;
    public Button settings;
    public Button exit;
    public Button FullScreen;
    //public bool SettingMenu;
    public Canvas SettingMenu;

    public void Start ()
    {
        start = start.GetComponent<Button>();
        settings = settings.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        FullScreen = FullScreen.GetComponent<Button>();
        SettingMenu.enabled = false;

    }
    
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }

    public void Settings ()
    {
        
        if (SettingMenu.enabled == true)
        {
            SettingMenu.enabled = false;
        }
        else
            SettingMenu.enabled = true;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetFullScreen() {
        // Screen.SetResolution(600, 800, true, 60);
        if (Screen.fullScreen == true)
           Screen.fullScreen = false;
        else
           Screen.fullScreen = true;
    }

    public void SetVolume()
    {

    }

    public void SetKeyBind()
    {
        
    }
}