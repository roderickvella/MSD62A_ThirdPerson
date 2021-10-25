using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BottomMenuManager : MonoBehaviour
{
    [Tooltip("Bottom Menu Panel")]
    public GameObject BottomMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        BottomMenuPanel.SetActive(false);
    }

    public void ShowBottomMenu(bool showMenu, string text = "")
    {
        BottomMenuPanel.SetActive(showMenu);
        BottomMenuPanel.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
