using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GamePause = false;
    public GameObject PauseMenuUI;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
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

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }
}
