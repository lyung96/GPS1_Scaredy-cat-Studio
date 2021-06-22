using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //Movement
    public Rigidbody2D rb;
    public float Speed = 3.0f;
    public float JumpForce = 10f;
    public bool isGrounded = true;
    public Animator anim;

    //Dash
    float horizontal;
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    public float DashForce = 30f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 1.0f;
    private float dashDirection = 1;
    float normalGravity; 
    //combat scripts
    public Transform atkPoint;
    public LayerMask enemyLayers;

    public float atkRange = 0.5f;
    public int atkDmg = 1;
    public float atkRate = 2f;
    float nextAtkTime = 0f;

    private bool isBlock = false;


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
        normalGravity = rb.gravityScale;
    }

    void Update()
    {
        PlayerControl();
    }

    public void PlayerControl()
    {
        if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("blocking", true);
            isBlock = true;
        }
        else if (Input.GetKey(KeyCode.A) && (isBlock == false))
        {
            rb.velocity = new Vector2(-(Speed), rb.velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;

            anim.SetBool("running", true);
            gameObject.transform.localScale =new Vector2(-1, 1);
            dashDirection = -1;
        } 
        else if (Input.GetKey(KeyCode.D) && (isBlock == false))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().flipX = false;

            anim.SetBool("running", true);
            gameObject.transform.localScale = new Vector2(1, 1);
            dashDirection = 1;
        }

        else
        {
            anim.SetBool("running", false);
            anim.SetBool("blocking", false);
            isBlock = false;
        }

        //check dashing direction
        if(horizontal != 0)
        {
            dashDirection = horizontal;
        }

        //Dash
        if(Input.GetKeyDown(KeyCode.LeftShift) && (canDash == true))
        {        
            //Stop Dash if running before calling another dash
            if (dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(dashDuration, dashCooldown);
            StartCoroutine(dashCoroutine);
        }

        //Attack, current time greater than next available attack time
        if (Time.time >= nextAtkTime)
        {
            if (Input.GetKeyDown(KeyCode.Z) && (isBlock == false))
            {
                StartCoroutine(Attack());
                //calculate next available atk time
                nextAtkTime = Time.time + 1f / atkRate;
            }
        }

        //Testing -Hp
        if (Input.GetKeyDown(KeyCode.X))
        {
            CalHp(1);
        }

        //Testing -Mp
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

    public void FixedUpdate()
    {
        if(isDashing == true)
        {
            rb.AddForce(new Vector2(dashDirection * DashForce, 0), ForceMode2D.Impulse);
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

    IEnumerator Attack()
    {
        anim.SetTrigger("attack");
        //Detect enemies in range of attack, store the hitted enemy in array
        yield return new WaitForSeconds(0.2f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayers);
        
        //Damage them all of the enemy in array
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().CalculateHealth(atkDmg);
        }
    }

    public void CalHp(int dmg)
    {
        int actualDmg = dmg;
        if(isBlock == true)
        {
            //actualDmg = (dmg /5);
            actualDmg = 0;
        }
        currHp -= actualDmg;
        hpBar.SetHealth(currHp);
        StartCoroutine(FlashRed());

        if (currHp <= 0)
        {
            Die();//Die or reload on checkpoint, come out losing screen
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

    //Show the attack range in scene
    private void OnDrawGizmosSelected()
    {
        if (atkPoint == null)
            return;

        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }

    public IEnumerator FlashRed()
    {      
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Dash(float DashDuration, float dashCooldown)
    {
        Vector2 originalVelocity = rb.velocity;
        isDashing = true;
        canDash = false;
        //making sure it doesn't affect by gravity and dash downward in air
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        //wait seconds, how long is dash then start cooldown
        yield return new WaitForSeconds(DashDuration);
        isDashing = false;
        //get back our velocity & gravity after dash duration
        rb.gravityScale = normalGravity;
        rb.velocity =new Vector2(originalVelocity.x,0);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
