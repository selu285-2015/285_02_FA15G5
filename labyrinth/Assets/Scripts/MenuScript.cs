using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public Button start;
    public Button settings;
    public Button exit;

    public void Start ()
    {
        start = start.GetComponent<Button>();
        settings = settings.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
    }
    
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}