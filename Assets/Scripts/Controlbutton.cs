using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlbutton : MonoBehaviour
{
    private Button control;
    MenuButton menuButton;
    private void Start()
    {
        menuButton = FindObjectOfType<LevelChanger>().GetComponent<MenuButton>();
        control = gameObject.GetComponent<Button>();
        control.onClick.AddListener(menuButton.controls);
    }
}
