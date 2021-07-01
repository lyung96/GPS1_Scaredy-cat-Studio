using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public OptionMenu OptionMenu;
    public static bool GamePause = false;
    public GameObject PauseMenuUI;

    private void Start()
    {
        OptionMenu = GetComponent<OptionMenu>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Debug.Log("Resume");
                Resume();
            }
            else if (OptionMenu.Option)
            {
                Debug.Log("Options");
                ClosePauseWhenOption();
            }
            else 
            {
                Debug.Log("Paused");
                Pause();
            }
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    public void ClosePauseWhenOption()
    {
        PauseMenuUI.SetActive(false);
        OptionMenu.Option = true;
        Time.timeScale = 0f;
        GamePause = true;
    }
   
    
}
