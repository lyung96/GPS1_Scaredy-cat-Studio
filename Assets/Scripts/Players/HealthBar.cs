using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient hpGradient;
    public Image hpFill;
    public GameObject player;
    public void SetMaxHealth(float health, float startinghealth)
    {
        hpSlider.maxValue = health;
        hpSlider.value = startinghealth;

       hpFill.color = hpGradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        hpSlider.value = health;

        hpFill.color = hpGradient.Evaluate(hpSlider.normalizedValue);        
    }

}
