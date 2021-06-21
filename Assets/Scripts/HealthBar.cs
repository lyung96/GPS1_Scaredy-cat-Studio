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
    public void SetMaxHealth(int health)
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;

       hpFill.color = hpGradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        hpSlider.value = health;

        hpFill.color = hpGradient.Evaluate(hpSlider.normalizedValue);
        if(health <= 0)
        {
            PlayerDie();
        }
    }    

    public void PlayerDie()
    {
        Destroy(player);
        Debug.Log("Player died");
    }

}
