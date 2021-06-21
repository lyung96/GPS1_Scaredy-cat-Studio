using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void CalculateHealth(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        //Play die animation and disable the enemy
        Destroy(gameObject);
    }

    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(FlashRed());
        }
    }*/

    public IEnumerator FlashRed()
    {
        //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        //gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        sprite.color = Color.yellow;
    }
}
