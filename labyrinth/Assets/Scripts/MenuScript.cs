using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public Button start;
    public Button settings;
    public Button exit;
    public Toggle FullScreen;
    public Canvas SettingMenu;
    public Dropdown ResDropDown;

    public void Start ()
    {
        start = start.GetComponent<Button>();
        settings = settings.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        FullScreen = FullScreen.GetComponent<Toggle>();
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
        if (Screen.fullScreen == true)
           Screen.fullScreen = false;
        else
           Screen.fullScreen = true;
    }
    public void SetResolution()
    {
        switch (ResDropDown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1680, 1050, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1600, 1024, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 4:
                Screen.SetResolution(1400, 900, Screen.fullScreen);
                break;
            case 5:
                Screen.SetResolution(1366, 768, Screen.fullScreen);
                break;
            case 6:
                Screen.SetResolution(1360, 768, Screen.fullScreen);
                break;
            case 7:
                Screen.SetResolution(1280, 1024, Screen.fullScreen);
                break;
            case 8:
                Screen.SetResolution(1280, 960, Screen.fullScreen);
                break;
            case 9:
                Screen.SetResolution(1280, 800, Screen.fullScreen);
                break;
            case 10:
                Screen.SetResolution(1280, 768, Screen.fullScreen);
                break;
            case 11:
                Screen.SetResolution(1152, 864, Screen.fullScreen);
                break;
            case 12:
                Screen.SetResolution(1024, 768, Screen.fullScreen);
                break;
        }
    }
    public void SetVolume()
    {

    }

    public void SetKeyBind()
    {
        
    }
}