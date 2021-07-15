using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject  optionsPanel;

    public void Awake()
    {
        optionsPanel = FindObjectOfType<OptionMenu>().OptionsMenuUI;
    }

    public void StartGame()
    {
        //pauseMenu = FindObjectOfType<PauseMenu>().PauseMenuUI;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GameLevel1");
        FindObjectOfType<AudioManager>().changeScene();
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
        FindObjectOfType<AudioManager>().changeScene();
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().StopPlaying("LevelMusic");
    }

    public void optionMenu()
    {
        GameObject mainMenuUI = GameObject.Find("MainMenu");
        mainMenuUI.transform.GetChild(0).gameObject.SetActive(false);
        optionsPanel.SetActive(true);
        //MainMenu.SetActive(false);
        //optionsMenu.SetActive(true);
    }
   public void inGameOptionMenu()
    {
        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        pauseMenu.PauseMenuUI.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void optionBack()
    {
        if(SceneManager.GetActiveScene().name != "Menu")
        {
            PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
            pauseMenu.PauseMenuUI.SetActive(true);
            optionsPanel.SetActive(false);
        }
        else
        {
            GameObject mainMenuUI = GameObject.Find("MainMenu");
            mainMenuUI.transform.GetChild(0).gameObject.SetActive(false);
            optionsPanel.SetActive(false);
            //GameObject mainMenuUI = FindObjectOfType<MainMenuControl>().mainMenuUI;
            //mainMenuUI.SetActive(true);
            //optionsPanel.SetActive(false);
        }
    }

    /*public void BackToMain()
    {
        FindObjectOfType<AudioManager>().changeScene();
        MainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }*/

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
