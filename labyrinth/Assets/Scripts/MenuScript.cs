using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {
public class MenuScript : MonoBehaviour
{

	// Use this for initialization
	public void Start () {
        Application.LoadLevel("main");
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
	
	// Update is called once per frame
	public void Exit () {
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
}