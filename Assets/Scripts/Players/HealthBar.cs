using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient hpGradient;
    public Image hpFill;
    public GameObject player;
    private float currHealth;
    private float lastHealth;
    private float maxHealth;

    private void Start()
    {
        player = GameObject.Find("Player");
        currHealth = player.GetComponent<PlayerController>().currHealth;
        lastHealth = player.GetComponent<PlayerController>().maxCurseBar;
        maxHealth = player.GetComponent<PlayerController>().maxCurseBar;
        SetMaxHealth(lastHealth, lastHealth);
        SetHealth(lastHealth);
    }

    private void Update()
    {
        currHealth = player.GetComponent<PlayerController>().currHealth;
        SetHealth(currHealth);
    }

    public void SetMaxHealth(float health, float startinghealth)
    {
        hpSlider.maxValue = health;
        hpSlider.value = startinghealth;

       hpFill.color = hpGradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        //if(SceneManager.GetActiveScene().name == "GameLevel1")
        //{
        maxHealth = player.GetComponent<PlayerController>().maxCurseBar;
        hpSlider.value = maxHealth - health;
        //}
        //else
        //{
        //    hpSlider.value = health;
        //}

        hpFill.color = hpGradient.Evaluate(hpSlider.normalizedValue);        
    }

}
