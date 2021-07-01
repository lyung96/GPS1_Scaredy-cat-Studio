using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public static bool Option = false;
    public GameObject OptionsMenuUI, PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void Optionmenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        Option = true;
        OptionsMenuUI.SetActive(true);
    }

    public void GoBackToPause()
    {
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        Option = false;
        PauseMenuUI.SetActive(true);

    }
}
