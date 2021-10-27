using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject Canvas;

    public List<Vector3> PandoraSpawnBoxes;
    public GameObject PandoraBoxPrefab;
    public GameObject PandoraBoxesPlaceHolder;


    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        SpawnPandoraBoxes();
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

    private void SpawnPandoraBoxes()
    {
        for(int i = 0; i < PandoraSpawnBoxes.Count; i++)
        {
            //spawn the object
            GameObject spawnedObject = Instantiate(PandoraBoxPrefab, PandoraSpawnBoxes[i], Quaternion.identity);
            //make the spawnobject as a child of pandoraboxes placeholder
            spawnedObject.transform.parent = PandoraBoxesPlaceHolder.transform;
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
