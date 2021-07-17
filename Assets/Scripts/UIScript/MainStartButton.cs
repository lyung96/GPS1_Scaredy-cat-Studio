using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStartButton : MonoBehaviour
{
    private Button startButton;
    MenuButton menuButton;
    // Start is called before the first frame update
    void Start()
    {
        menuButton = FindObjectOfType<LevelChanger>().GetComponent<MenuButton>();
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(menuButton.StartGame);
    }
}
