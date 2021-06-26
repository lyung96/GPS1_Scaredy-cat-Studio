using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currEnemyHp;

    public HealthBar enemyHpBar;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        currEnemyHp = maxHealth;
        enemyHpBar.SetMaxHealth(maxHealth, currEnemyHp);
    }


    public void CalculateHealth(int damage)
    {
        currEnemyHp -= damage;
        enemyHpBar.SetHealth(currEnemyHp);
        StartCoroutine(FlashRed());

        if (currEnemyHp <= 0)
        {
            Die();
            ScoreSystem.scoreNum += 1;
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
