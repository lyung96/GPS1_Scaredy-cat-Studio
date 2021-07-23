using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currEnemyHp;
    private bool enemyDied;

    public HealthBar enemyHpBar;
    public SpriteRenderer sprite;

    public PlayerController playerController;
    public GameObject player;
    private ParticleSystem bloodEffect;

    public bool enemydie;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        bloodEffect = gameObject.GetComponentInChildren<ParticleSystem>();
        currEnemyHp = maxHealth;
        enemyHpBar.SetMaxHealth(maxHealth, currEnemyHp);
        enemyDied = false;
}


    public void CalculateHealth(int damage)
    {
        if (enemyDied == false)
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            currEnemyHp -= damage;
            enemyHpBar.SetHealth(currEnemyHp);
            StartCoroutine(FlashRed());

            if (currEnemyHp <= 0)
            {
                enemyDied = true;
                chestopener.enemycount++;
                Debug.Log("enemy count: " + chestopener.enemycount);
                Die();
                PlayerController.exp += 1;
                ScoreSystem.scoreNum += 1;
            }
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        //Play die animation and disable the enemy
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1f);
        enemydie = true;
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
        bloodEffect.Play();
        yield return new WaitForSeconds(0.1f);
        //gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        sprite.color = Color.yellow;

    }
}
