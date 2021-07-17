using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainOptionButton : MonoBehaviour
{
    private Button optionButton;
    MenuButton menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuButton = FindObjectOfType<LevelChanger>().GetComponent<MenuButton>();
        optionButton = GetComponent<Button>();
        optionButton.onClick.AddListener(menuButton.optionMenu);
    }
}
