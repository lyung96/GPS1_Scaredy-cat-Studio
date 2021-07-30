using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHuman : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient hpGradient;
    public Image hpFill;
    public GameObject player;
    private float currHealth;
    private float lastHealth;

    private void Start()
    {
        player = GameObject.Find("Player");
        currHealth = player.GetComponent<PlayerController>().currHealth;
        lastHealth = player.GetComponent<PlayerController>().maxCurseBar;
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
        hpSlider.value = 6 - health;

        hpFill.color = hpGradient.Evaluate(hpSlider.normalizedValue);
    }
}
