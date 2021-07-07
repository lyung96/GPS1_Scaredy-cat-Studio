using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject PauseMenuUI;


    public void Start()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        FindObjectOfType<AudioManager>().SetVolume("LevelMusic", 0.2f);
    }

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
        FindObjectOfType<AudioManager>().SetVolume("LevelMusic", 0.05f);
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        FindObjectOfType<AudioManager>().SetVolume("LevelMusic", 0.2f);
    }
}
