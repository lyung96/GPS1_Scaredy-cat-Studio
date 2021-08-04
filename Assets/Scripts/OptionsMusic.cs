using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMusic : MonoBehaviour
{
    [Range(0.0f, 1f)]
    [SerializeField]
    private float masterVolume = 1f;
    public Slider slider;
    GameObject optionMenu;

    // Start is called before the first frame update
    void Start()
    {
        optionMenu = GameObject.Find("Options Menu");
        slider = optionMenu.GetComponent<OptionMenu>().masterSlider;
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        masterVolume = slider.value;
        AudioListener.volume = masterVolume;
        
    }

    /*public void changeVolume(float level)
    {
        mixer.SetFloat("Volume", level);
    }*/
}
