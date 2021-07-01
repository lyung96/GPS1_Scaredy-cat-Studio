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
    private bool FacingRight = true;

    //Dash
    float horizontal;
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    public float DashForce = 30f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 1.0f;
    public float dashDirection = 1;
    float normalGravity; 

    //combat scripts
    public Transform atkPoint;
    public LayerMask enemyLayers;

    public float firepillarRange = 0f;
    public int firepillarDamage = 3;
    public float atkRange = 0.5f;
    public int atkDmg = 1;
    public float atkRate = 2f;
    float nextAtkTime = 0f;

    private bool isBlock = false;

    public Transform firepillarPoint;
    public Transform firePoint;
    public ShurikenController shurikenController; //icon
    public GameObject shurikenPrefab; 
    public GameObject fireball;
    public GameObject fireball2;
    public GameObject firepillar;
    public float attackRangeX;
    public float attackRangeY;
    private SwitchMask mask;

    //health
    public float maxCurse = 6f; //bar
    public float currCurse ; //bar
    public HealthBar curseBar; //bar
    //private float damage; Icon
    //private HealthController healthController; //icon

    //mana
    //public int maxMp = 4; //bar
    // public int currMp; //bar
    //public ManaBar mpBar; //bar
    public int maxMana = 3;
    public ManaController manaController; //Icon

    //mask
    public int maskCollected = 0;

    public float Exp = 0;

    private void Start()
    {
        //healthController = GetComponent<HealthController>(); //Icon
        shurikenController = GetComponent<ShurikenController>(); //Icon
        manaController = GetComponent<ManaController>(); //Icon
        currCurse = 0; 
        //currHp = healthController.maxHealth; //icon
        manaController.maxMana = maxMana; //icon
        curseBar.SetMaxHealth(maxCurse, currCurse); //bar
        //mpBar.SetMaxMana(maxMp); //bar
        normalGravity = rb.gravityScale;
        mask = GetComponent<SwitchMask>();//Icon
    }

    void Update()
    {
        PlayerControl();
        if(manaController.currMana < manaController.maxMana)
        {
             InvokeRepeating("RegenMana", 10f, 10f);
        }

        if (shurikenController.shuriken < shurikenController.numOfShuriken)
        {
            InvokeRepeating("RegenShuriken", 3f, 3f);
        }
    }

    public void PlayerControl()
    {
        if (Input.GetKey(KeyCode.F))
        {
            anim.SetBool("blocking", true);
            isBlock = true;
        }
        else if (Input.GetKey(KeyCode.A) && (isBlock == false))
        {
            rb.velocity = new Vector2(-(Speed), rb.velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;

            anim.SetBool("running", true);
            if(FacingRight == true)
            {
                Flip();               
            }
            //gameObject.transform.localScale =new Vector2(-1, 1);
            dashDirection = -1;
        } 
        else if (Input.GetKey(KeyCode.D) && (isBlock == false))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().flipX = false;

            anim.SetBool("running", true);
            if (FacingRight == false)
            {
                Flip();
            }
            //gameObject.transform.localScale = new Vector2(1, 1);
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
        if(Input.GetKeyDown(KeyCode.LeftShift) && (canDash == true) && (isBlock == false))
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
            if (Input.GetMouseButtonDown(0) && (isBlock == false))
            {
                StartCoroutine(Attack());
                //calculate next available atk time
                nextAtkTime = Time.time + 1f / atkRate;
            }
        }

        //Testing -Hp
        if (Input.GetKeyDown(KeyCode.X))
        {
            CalHp(1.0f);
            //damage = CalHp(1.0f);
            //healthController.TakeDamage(damage);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CalHp(0.5f);
            //damage = CalHp(0.5f);
            //healthController.TakeDamage(0.5f);
        }

        //Testing +Mp
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //CalMp(1);
            manaController.ReplenishMana();
        }

        //+MaxMana
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //maxMp += 1;
            manaController.maxMana++;
            //mpBar.SetMaxMana(maxMp);
            //CalMp(0);
        }

        //Shuriken
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(shurikenController.shuriken > 0)
            {
                ShootShuriken();
                shurikenController.UseShuriken();
            }
        }

        //Mask Skill
        if (Input.GetKeyDown(KeyCode.R) && (manaController.currMana > 0))
        {
            if ((mask.mask1active == true) && (manaController.currMana >0)) //if maskcollected = 1
            {
                ShootFireball();
                Debug.Log("Mask 1 Skill activated");
                manaController.UseMana(-1);
                //CalMp(-1);
            }
            else if (mask.mask2active == true && (manaController.currMana > 1)) //else maskcollected = 2
            {
                //FirePillar();
                //FirePillarAttack();
                ShootFireball2();
                Debug.Log("Mask 2 Skill activated");
                manaController.UseMana(-2);
            }
            else if (mask.mask3active == true)
            {

            }
        }

        /*if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }*/

   

        if (isGrounded == true && !Input.GetKey(KeyCode.S))
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
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Grappling")
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

    public void FirePillarAttack()
    {
        //Detect enemies in range of attack, store the hitted enemy in array
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(firepillarPoint.position, new Vector2(attackRangeX, attackRangeY),0, enemyLayers);

        //Damage them all of the enemy in array
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().CalculateHealth(firepillarDamage);
        }
    }

    public void CalHp(float dmg)
    {
        float actualDmg = dmg;
        if(isBlock == true)
        {
            if(manaController.currMana > 0)
            {
                //CalMp(-1);
                manaController.currMana--;
                actualDmg = 0;
            }
            else
            {
                actualDmg = (dmg /2);
            }
        }
        currCurse += actualDmg;
        curseBar.SetHealth(currCurse);
        if(currCurse >= maxCurse)
        {
            Die();
        }
        StartCoroutine(FlashRed());
        //return actualDmg;
    }

    /*public void CalMp(int mana)
    {
        currMp += mana;
        //mpBar.SetMana(currMp);
    }*/

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
        Gizmos.DrawWireCube(firepillarPoint.position, new Vector3(attackRangeX,attackRangeY, 1));
    }


    public void RegenMana()
    {
        if (manaController.currMana < manaController.maxMana)
        {
            manaController.currMana++;
            //mpBar.SetMana(currMp);
            CancelInvoke("RegenMana");
        }
    }

    public void RegenShuriken()
    {
        if (shurikenController.shuriken < shurikenController.numOfShuriken)
        {
            shurikenController.shuriken++;
            CancelInvoke("RegenShuriken");
        }
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
    void ShootShuriken()
    {
        Instantiate(shurikenPrefab, firePoint.position, firePoint.rotation);
    }
    public void ShootFireball()
    {
        Instantiate(fireball, firePoint.position, firePoint.rotation);
    }
    public void ShootFireball2()
    {
        Instantiate(fireball2, firePoint.position, firePoint.rotation);
    }
    public void FirePillar()
    {
        Instantiate(firepillar, firepillarPoint.position, firepillarPoint.transform.rotation);
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Load()
    {
        manaController.numOfMana = maxMana;
        manaController.maxMana = maxMana;
        curseBar.SetMaxHealth(maxCurse, currCurse); //bar
        currCurse = 0;
        curseBar.SetHealth(0);
        shurikenController.shuriken = 3;
    }
}
