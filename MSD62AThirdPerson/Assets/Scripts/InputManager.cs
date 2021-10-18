using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void KeyEvent(KeyCode key);
    public static event KeyEvent KeyDown;

    //list containing keycodes in our game
    private List<KeyCode> keyCodes;


    // Start is called before the first frame update
    void Start()
    {
        //loading all keys and storing them inside the list keyCodes
        keyCodes = new List<KeyCode>((KeyCode[])System.Enum.GetValues(typeof(KeyCode)));
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCodes == null)
            return; //do not execute code after this line if keyCodes is null

        for(int i = 0; i < keyCodes.Count; i++)
        {
            if(KeyDown!=null && Input.GetKeyDown(keyCodes[i]))
            {
                KeyDown(keyCodes[i]);
            }
        }
    }
}
