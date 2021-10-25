using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Collision with:" + other.gameObject.name);
        GameManager.Canvas.GetComponentInChildren<BottomMenuManager>().ShowBottomMenu(true, "Press E to collect box");
    }

    private void OnTriggerExit(Collider other)
    {
        print("Exiting Collision");
        GameManager.Canvas.GetComponentInChildren<BottomMenuManager>().ShowBottomMenu(false);
    }
}
