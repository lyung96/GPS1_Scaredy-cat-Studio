using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    PauseMenu pauseMenu;

    public void StartGame()
    {
        pauseMenu = GetComponent<PauseMenu>();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GameLevel1");
        FindObjectOfType<AudioManager>().Play("LevelMusic");
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().StopPlaying("LevelMusic");

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            FindObjectOfType<AudioManager>().Play("LevelMusic");
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
        }
    }
}
