using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainQuitButton : MonoBehaviour
{
    private Button quitButton;
    MenuButton menuButton;
    // Start is called before the first frame update
    void Start()
    {
        menuButton = FindObjectOfType<LevelChanger>().GetComponent<MenuButton>();
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(menuButton.QuitGame);
    }
}
