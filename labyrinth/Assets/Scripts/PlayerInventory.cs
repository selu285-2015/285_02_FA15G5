using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {
    bool item1;
    GUIStyle style = new GUIStyle();
    public Font myFont;

    void Start()
    {
        item1 = false;
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        style.font = myFont;
    }

    public void SetInventory(bool set)
    {
        item1 = set;
    }

   void OnGUI()
    {

        if (item1 == true){
            GUI.Label(new Rect(20, 100, 200, 100), "Player inventory: \n Lever Piece", style);
        }

        if(item1 == false)
        {
            GUI.Label(new Rect(20, 100, 200, 100), "Player inventory:", style);
        }

    }
}
