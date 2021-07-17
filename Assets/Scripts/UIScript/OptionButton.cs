using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    private Button optionButton;
    MenuButton menuButton;
    // Start is called before the first frame update
    void Start()
    {
        menuButton = FindObjectOfType<LevelChanger>().GetComponent<MenuButton>();
        optionButton = gameObject.GetComponent<Button>();
        optionButton.onClick.AddListener(menuButton.inGameOptionMenu);
    }
}
