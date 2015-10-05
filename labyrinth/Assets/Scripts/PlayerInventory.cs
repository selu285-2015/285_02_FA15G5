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
        GUI.Label(new Rect(20, 100, 200, 100), "Player inventory: \n Item 1: " + item1);
    }
}
