using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public int numOfHeart;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public Image[] hearts;

 // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > numOfHeart)
        {
            currentHealth = numOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if(i < currentHealth)
            {
                if(i + 0.5 == currentHealth)
                {
                    hearts[i].sprite = halfHeart;
                }
                else
                {
                    hearts[i].sprite = fullHeart;
                }
            }
            else
            {
                hearts[i].sprite = emptyHeart; 
            }
        }

        /*if(currentHealth < maxHealth)
        {
            InvokeRepeating("RegenHealth", 2f, 2f);
        }*/

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float dmg)
    {
        if(currentHealth > 0)
        {
            currentHealth -= dmg;
            
            if(currentHealth <=  0)
            {
                currentHealth = 0;
            }
        }
    }

    public void Heal(float heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    public void RegenHealth()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += 0.5f;
            CancelInvoke("RegenHealth");
        }
    }
}
