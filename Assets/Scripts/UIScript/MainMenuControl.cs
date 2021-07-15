using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    public GameObject mainMenuUI;
    GameObject optionMenu;
    GameObject optionUI;
    // Start is called before the first frame update
    void Start()
    {
        optionMenu = GameObject.Find("Options Menu");
        optionUI = optionMenu.transform.GetChild(0).gameObject;
        mainMenuUI = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!optionUI.activeInHierarchy)
        {
            GameObject mainMenuUI = GameObject.Find("MainMenu");
            mainMenuUI.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
