using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject nextToBox;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable()
    {
        InputManager.KeyDown += ObserverKeyDown;
    }

    private void OnDisable()
    {
        InputManager.KeyDown -= ObserverKeyDown;
    }

    private void ObserverKeyDown(KeyCode keyCode)
    {
        if(keyCode == KeyCode.E)
        {
            RemoveBox();
        }
        else if(keyCode == KeyCode.F)
        {
            StartShooting();
        }
    }

    private void StartShooting()
    {
        //trigger the param inside the controller
        animator.SetTrigger("WeaponShoot");

    }

    private void RemoveBox()
    {
        Destroy(nextToBox);
        GameManager.Canvas.GetComponentInChildren<BottomMenuManager>().ShowBottomMenu(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        print("Collision with:" + other.gameObject.name);
        GameManager.Canvas.GetComponentInChildren<BottomMenuManager>().ShowBottomMenu(true, "Press E to collect box");
        nextToBox = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        print("Exiting Collision");
        GameManager.Canvas.GetComponentInChildren<BottomMenuManager>().ShowBottomMenu(false);
        nextToBox = null;
    }
}
