using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButtonBack : MonoBehaviour
{
    public void OptionBackButtons()
    {
        MenuButton menuButton = GameObject.Find("LevelChanger").GetComponent<MenuButton>();
        if (menuButton != null)
        {
            menuButton.optionBack();
        }
    }
}
