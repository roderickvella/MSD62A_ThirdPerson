using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        InputManager.KeyDown += ObserverKeyPress;
    }

    private void OnDisable()
    {
        InputManager.KeyDown -= ObserverKeyPress;
    }

    public void ObserverKeyPress(KeyCode keyCode)
    {
        if(keyCode == KeyCode.Tab)
        {
            ShowToggleInventory();
        }
    }

    private void ShowToggleInventory()
    {
        //ShowToggleInventory inside InventoryManager
        GameObject.Find("Canvas").GetComponentInChildren<InventoryManager>().ShowToggleInventory();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
