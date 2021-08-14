using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMusic : MonoBehaviour
{
    [Range(0.0f, 1f)]
    [SerializeField]
    public static float masterVolume;
    public static Slider slider;
    GameObject optionMenu;
    private string lastScene, currScene;
    public bool startVol = true;


    // Start is called before the first frame update
    void Start()
    {
        lastScene = SceneManager.GetActiveScene().name;
        optionMenu = GameObject.Find("Options Menu");
        slider = optionMenu.GetComponent<OptionMenu>().masterSlider;
        changeScene();
    }

    // Update is called once per frame
    void Update()
    {
        masterVolume = slider.value;
        AudioListener.volume = masterVolume;
    }

    void changeScene()
    {
        float currMasVol = masterVolume;
        currScene = SceneManager.GetActiveScene().name;
        if (lastScene != currScene)
        {
            slider.value = currMasVol;
            lastScene = currScene;
        }
    }

    /*public void changeVolume(float level)
    {
        mixer.SetFloat("Volume", level);
    }*/
}
