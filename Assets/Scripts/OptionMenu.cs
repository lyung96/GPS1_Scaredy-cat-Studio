using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public static bool Option = false;
    public GameObject OptionsMenuUI; //PauseMenuUI;

    public Slider oBgSlider;
    public Slider oSfxSlider;
    public Slider masterSlider;

    public static OptionMenu instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        OptionMenuPos();
        OptionsMenuUI = gameObject.transform.GetChild(0).gameObject;
    }

    /*public void Optionmenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        Option = true;
        OptionsMenuUI.SetActive(true);
    }*/

    /*public void GoBackToPause()
    {
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        Option = false;
        PauseMenuUI.SetActive(true);
    }*/

    public void OptionMenuPos()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            OptionsMenuUI.GetComponent<RectTransform>().localPosition = new Vector3(29, -131, 0);
        }
        else
        {
            OptionsMenuUI.GetComponent<RectTransform>().localPosition = new Vector3(35, -42 , 0);
        }
    }
}
