using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    PauseMenu pauseMenu;
    public GameObject MainMenu, optionsMenu;

    public void StartGame()
    {
        pauseMenu = GetComponent<PauseMenu>();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GameLevel1");
        FindObjectOfType<AudioManager>().Play("LevelMusic");
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().StopPlaying("LevelMusic");
    }

    public void optionMenu()
    {
        MainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackToMain()
    {
        MainMenu.SetActive(true);
        optionsMenu.SetActive(false);
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
