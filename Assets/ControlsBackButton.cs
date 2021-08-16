using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsBackButton : MonoBehaviour
{

    public void ControlsBackButtons()
    {
        MenuButton menuButton = GameObject.Find("LevelChanger").GetComponent<MenuButton>();
        if(menuButton != null)
        {
            menuButton.controlBack();
        }
    }
}
