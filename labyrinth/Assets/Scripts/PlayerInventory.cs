using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {
    bool item1;

    void Start()
    {
        item1 = false;
    }

    public void SetInventory(bool set)
    {
        item1 = set;
    }

   void OnGUI()
    {
		GUI.contentColor = Color.red;
        if(item1 == true){
            GUI.Label(new Rect(20, 100, 200, 100), "Player inventory: \n Item 1");
        }

        if(item1 == false)
        {
            GUI.Label(new Rect(20, 100, 200, 100), "Player inventory:");
        }

    }
}
