using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 3.0f;
    public float JumpForce = 10f;
    public bool isGrounded = true;
    public Animator anim;

    //combat scripts
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int atkDmg = 1;

    //health
    public int maxHp = 10;
    public int currHp;
    public HealthBar hpBar;

    //mana
    public int maxMp = 10;
    public int currMp;
    public ManaBar mpBar;

    private void Start()
    {
        currHp = maxHp;
        currMp = maxMp;
        hpBar.SetMaxHealth(maxHp);
        mpBar.SetMaxMana(maxMp);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    public void PlayerControl()
    {
        //if collide den cannot press
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-(Speed), rb.velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;

            anim.SetBool("running", true);
            gameObject.transform.localScale =new Vector2(-1, 1);
        } else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().flipX = false;

            anim.SetBool("running", true);
            gameObject.transform.localScale = new Vector2(1, 1);
        } else
        {
            anim.SetBool("running", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            CalHp(1);
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CalMp(1);
        }

        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Touch Ground ");
            isGrounded = true;
        }
    }

    void Attack()
    {
        //Play animation
        anim.SetTrigger("attack");
        //Detect enemies in range of attack, store the hitted enemy in array
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //Damage them all of the enemy in array
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().CalculateHealth(atkDmg);
        }
    }

    public void CalHp(int dmg)
    {
        currHp -= dmg;
        hpBar.SetHealth(currHp);
        StartCoroutine(FlashRed());

        if (currHp <= 0)
        {
            Die();
        }
    }

    public void CalMp(int mana)
    {
        currMp -= mana;
        mpBar.SetMana(currMp);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public IEnumerator FlashRed()
    {
        //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        //gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //sprite.color = Color.yellow;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
