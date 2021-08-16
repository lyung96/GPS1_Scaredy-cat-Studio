using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject PauseMenuUI;


    public void Start()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        //FindObjectOfType<AudioManager>().SetVolume("LevelMusic", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionMenu.Option==false)
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
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
        FindObjectOfType<AudioManager>().SetVolume("LevelMusic", 0.3f);
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameObject optionMenu = GameObject.Find("Options Menu").gameObject.transform.GetChild(0).gameObject;
        if(SceneManager.GetActiveScene().name != "GameLevel1")
        {
            GameObject controlMenu = GameObject.Find("Controls").gameObject.transform.GetChild(0).gameObject;
            controlMenu.SetActive(false);
        }
        optionMenu.SetActive(false);        
        Time.timeScale = 1f;
        GamePause = false;
        FindObjectOfType<AudioManager>().SetVolume("LevelMusic", 1f);
    }

}
