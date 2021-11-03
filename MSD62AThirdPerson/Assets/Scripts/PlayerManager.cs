using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject nextToBox;
    private Animator animator;
    public GameObject Camera2;

    //projectile
    public GameObject projectile; //grenade
    public Transform projectileSpawnSpot; //weaponcontainer

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
        //enable camera2
        Camera2.SetActive(true);

        //trigger the param inside the controller
        animator.SetTrigger("WeaponShoot");

        //Call IStopShooting to wait 5 seconds and set camera2 back to false
        StartCoroutine(IStopShooting());
        StartCoroutine(Launch());

    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(projectile, projectileSpawnSpot.position, projectileSpawnSpot.rotation, gameObject.transform);
    }

    IEnumerator IStopShooting()
    {
        yield return new WaitForSeconds(5f);
        Camera2.SetActive(false);
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
