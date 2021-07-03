using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GameLevel1");
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
        FindObjectOfType<AudioManager>().Play("LevelMusic");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
            FindObjectOfType<AudioManager>().Play("LevelMusic");
        }
    }
}
