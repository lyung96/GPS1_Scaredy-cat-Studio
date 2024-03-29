using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement
    public Rigidbody2D rb;
    public float Speed = 3.0f;
    public float JumpForce = 10f;
    //public bool isGrounded = true;
    public Animator anim;
    private bool FacingRight = true;
    public static bool isDead;
    private bool isBlocking;

    //Dash
    private float horizontal;
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
    private bool jumpAttack;

    private bool isBlock = false;
    private bool canHurt = true;


    public Transform firepillarPoint;
    public Transform firePoint;
    [HideInInspector]
    public ShurikenController shurikenController; //icon
    public GameObject shurikenPrefab; 
    public GameObject fireball;
    public GameObject fireball2;
    public GameObject firepillar;
    public GameObject finalBlow;
    public float attackRangeX;
    public float attackRangeY;
    private SwitchMask mask;
    public GameObject finalBlowUi;
    private FinalBlowBar finalBlowBar;

    //health
    public float maxCurseBar = 6f; //bar
    public float currHealth ; //bar
    public HealthBar curseBar; //bar
    //private float damage; Icon
    //private HealthController healthController; //icon

    //mana
    //public int maxMp = 4; //bar
    // public int currMp; //bar
    //public ManaBar mpBar; //bar
    public int maxMana = 3;
    [HideInInspector]
    public ManaController manaController; //Icon
    public obtainedkey key;

    //mask
    public static int maskCollected;
    public float maskGauge = 0;
    public static float playerLevel = 1;
    public static float exp = 0;

    public static bool left, right, jump, dash, enddialogue;
    //Audio

    //Camera
    public CameraController cameraController;

    //Scene
    public string currScene;

    private void Start()
    {
        finalBlowBar = finalBlowUi.GetComponent<FinalBlowBar>();
        //healthController = GetComponent<HealthController>(); //Icon
        shurikenController = GetComponent<ShurikenController>(); //Icon
        manaController = GetComponent<ManaController>(); //Icon
        currHealth = maxCurseBar; 
        //currHp = healthController.maxHealth; //icon
        manaController.maxMana = maxMana; //icon
        curseBar.SetMaxHealth(maxCurseBar, currHealth); //bar
        //mpBar.SetMaxMana(maxMp); //bar
        normalGravity = rb.gravityScale;
        mask = GetComponent<SwitchMask>();//Icon
        currScene = SceneManager.GetActiveScene().name;
        maskCollected = 1;
    }

    void Update()
    {
        //if ()
        //{
        //    enddialogue = true;
        //}

        if (PauseMenu.GamePause == false && DialogKey.endDialogue == true && DialogBegining.endDialogue == true && UpgradeMenu.uiActive == false && obtainedkey.endDialogue && isDead == false && Level2beginingdialogue.endDialogue == true && goddessmessage.endDialogue == true && obtainedkey1.endDialogue && mothermessage.endDialogue && finaldialogue.endDialogue && Level2beginingdialogue.endDialogue && Level3beging.endDialogue && Level4begin.endDialogue)
        { 
            PlayerControl(); 
        }
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
        
        if (Input.GetKey(KeyCode.Tab) && currScene != "GameLevel1")
        {
            if (chestopener1.obtainedkey)
            {
                if (isBlocking == false)
                {
                    anim.SetTrigger("blocking");
                    anim.SetBool("isBlocking", true);
                    isBlocking = true;
                }
                isBlock = true;
            }
            
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
            left = true;

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
            right = true;
        }
        else
        {
            anim.SetBool("running", false);
            anim.SetBool("isBlocking", false);
            anim.ResetTrigger("blocking");
            isBlock = false;
            isBlocking = false;
        }
        if (Groundcheck.isGrounded == true)
        {
            anim.SetBool("onGround", true);
            jump = false;
            jumpAttack = false;
        }

        //check dashing direction
        if (horizontal != 0)
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
            dash = true;
        }

        //Attack, current time greater than next available attack time
        if (Time.time >= nextAtkTime)
        {
            if (Input.GetMouseButtonDown(0) && (isBlock == false))
            {
                if(jumpAttack != true)
                {
                    StartCoroutine(Attack());
                    //calculate next available atk time
                    nextAtkTime = Time.time + 1f / atkRate;
                }                
            }
        }
       
        //Shuriken
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(shurikenController.shuriken > 0)
            {
                anim.SetTrigger("skill");
                ShootShuriken();
                shurikenController.UseShuriken();
            }
        }

        //Mask Skill
        if (Input.GetKeyDown(KeyCode.Q) && (manaController.currMana > 0) && currScene != "GameLevel1")
        {
            if(maskCollected == 0)
            {
                //disable maskui
                //disable manaui
            }
            if ((maskCollected == 1) && (manaController.currMana > 0) && chestopener1.obtainedkey) //if maskcollected = 1
            {
                anim.SetTrigger("skill");
                ShootFireball();
                Debug.Log("Mask 1 Skill activated");
                manaController.UseMana(-1);
                FindObjectOfType<AudioManager>().Play("Fireball");
                //CalMp(-1);
            }
            else if ((maskCollected == 2) && (manaController.currMana > 1)) //else maskcollected = 2
            {
                anim.SetTrigger("skill");
                //FirePillar();
                //FirePillarAttack();
                ShootFireball2();
                Debug.Log("Mask 2 Skill activated");
                manaController.UseMana(-2);
                FindObjectOfType<AudioManager>().Play("Fireball");
            }
            else if ((maskCollected == 3) && (manaController.currMana > 1))
            {
                if(maskGauge < 35)
                {
                    anim.SetTrigger("skill");
                    ShootFireball2();
                    manaController.UseMana(-2);
                    FindObjectOfType<AudioManager>().Play("Fireball");
                }
                else if(maskGauge >= 35)
                {
                    anim.SetTrigger("skill");
                    ShootFinalBlow();
                    Debug.Log("Mask 3 Skill activated");
                    FindObjectOfType<AudioManager>().Play("Fireball");
                }

            }
        }

        if (Groundcheck.isGrounded == true && !Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("onGround", false);
                anim.SetBool("jump", true);
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                Groundcheck.isGrounded = false;
                jump = true;
                GrapplePoint.isGrap = false;
            }
        }
        if(SceneManager.GetActiveScene().name == "GameLevel5" && maskCollected != 3)
        {
            getFinalMask();
        }

        TestingControl();


    }

    public void FixedUpdate()
    {
        if(isDashing == true)
        {
            rb.AddForce(new Vector2(dashDirection * DashForce, 0), ForceMode2D.Impulse);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Grappling")
        {
            Debug.Log("Touch Ground ");
            isGrounded = true;
        }
    }*/

    IEnumerator Attack()
    {
        if (jump == true)
        {
            jumpAttack = true;
            anim.SetTrigger("jumpAttack");
            FindObjectOfType<AudioManager>().Play("Slash");
        }
        else
        {
            anim.SetTrigger("attack");
            FindObjectOfType<AudioManager>().Play("Slash");
        }

        //Detect enemies in range of attack, store the hitted enemy in array
        yield return new WaitForSeconds(0.2f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayers);

        //Damage them all of the enemy in array
        foreach (Collider2D enemy in hitEnemies)
        {
            //if (enemy.CompareTag("Boss"))
            //{
            //    maskGauge += 1;
            //    finalBlowBar.SetBar(maskGauge);
            //    enemy.GetComponent<Enemy>().CalculateHealth(atkDmg);
            //}
            //Debug.Log("We hit " + enemy.name);
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>().CalculateHealth(atkDmg);
            }
            if (enemy.CompareTag("CatEnemy"))
            {
                StartCoroutine(enemy.GetComponent<EnemyCat>().EnemyTakeDamage(-atkDmg));
            }
            if (enemy.CompareTag("Boss"))
            {
                maskGauge += 1;
                finalBlowBar.SetBar(maskGauge);
                StartCoroutine(enemy.GetComponent<Boss>().BossTakeDamage(-atkDmg));
            }


        }
    }

    /*public void FirePillarAttack()
    {
        //Detect enemies in range of attack, store the hitted enemy in array
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(firepillarPoint.position, new Vector2(attackRangeX, attackRangeY),0, enemyLayers);

        //Damage them all of the enemy in array
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().CalculateHealth(firepillarDamage);
        }
    }*/

    public void CalHp(float dmg)
    {
        float actualDmg = dmg;
        if (canHurt == false)
        {
            StartCoroutine(FlashMagenta());
        }
        if (canHurt == true)
        {
            if (isBlock == true)
            {
                if (manaController.currMana > 0)
                {
                    //CalMp(-1);
                    manaController.currMana--;
                    actualDmg = 0;
                }
                else
                {
                    actualDmg = (dmg / 2);
                }
            }
            currHealth += actualDmg;
            curseBar.SetMaxHealth(maxCurseBar, currHealth);
            curseBar.SetHealth(currHealth);
            StartCoroutine(FlashRed());
        }
        if(currHealth <= 0)//currCurse >= maxCurse
        {
            Die();
        }
        else if (currHealth > 0)
        {
            anim.ResetTrigger("isDead");
            isDead = false;
        }
        if (currHealth >= maxCurseBar)
        {
            currHealth = maxCurseBar;
        }

        //return actualDmg;
    }

    /*public void CalMp(int mana)
    {
        currMp += mana;
        //mpBar.SetMana(currMp);
    }*/

    public void Die()
    {
        //gameObject.SetActive(false);
        if (isDead == false)
        {
            anim.SetTrigger("isDead");
            isDead = true;
        }

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
    public IEnumerator FlashMagenta()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Dash(float DashDuration, float dashCooldown)
    {
        anim.SetBool("dash", true);
        Vector2 originalVelocity = rb.velocity;
        canHurt = false;
        isDashing = true;
        canDash = false;
        //making sure it doesn't affect by gravity and dash downward in air
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        //wait seconds, how long is dash then start cooldown
        yield return new WaitForSeconds(DashDuration);
        anim.SetBool("dash", false);
        isDashing = false;
        canHurt = true;
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

    public void ShootFinalBlow()
    {
        Instantiate(finalBlow, firePoint.position, firePoint.rotation); //new Vector3 (firePoint.position.x + 15, firePoint.position.y, firePoint.position.z)
    }

    /*public void FirePillar()
    {
        Instantiate(firepillar, firepillarPoint.position, firepillarPoint.transform.rotation);
    }*/

    private void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Footstep()
    {
        if(Groundcheck.isGrounded == true)
        {
            FindObjectOfType<AudioManager>().Play("PlayerRun");
        }
    }

    public void Load()
    {
        manaController.numOfMana = maxMana;
        manaController.maxMana = maxMana;
        currHealth = maxCurseBar;        
        curseBar.SetMaxHealth(maxCurseBar, currHealth);//bar
        curseBar.SetHealth(maxCurseBar);
        shurikenController.shuriken = 3;
    }

    #region
    public void TestingControl()
    {
        //Testing -Hp
        if (Input.GetKeyDown(KeyCode.X))
        {
            CalHp(-1.0f);
            //damage = CalHp(1.0f);
            //healthController.TakeDamage(damage);
        }

        //Heal
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
            //manaController.maxMana++;
            manaController.numOfMana++;
            //mpBar.SetMaxMana(maxMp);
            //CalMp(0);
        }
        //+MaxMana
        if (Input.GetKeyDown(KeyCode.V))
        {
            maxCurseBar += 1;
            currHealth = maxCurseBar;
            curseBar.SetMaxHealth(maxCurseBar, currHealth);
            curseBar.SetHealth(currHealth);

        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            finalBlowUi.SetActive(false);
            maskCollected = 0;
            gameObject.GetComponent<SwitchMask>().SetMask(maskCollected);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            finalBlowUi.SetActive(false);
            maskCollected = 1;
            gameObject.GetComponent<SwitchMask>().SetMask(maskCollected);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))//if 2 is pressed
        {
            finalBlowUi.SetActive(false);
            maskCollected = 2;
            gameObject.GetComponent<SwitchMask>().SetMask(maskCollected);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))//if 3 is pressed
        {
            finalBlowUi.SetActive(true);
            maskCollected = 3;
            gameObject.GetComponent<SwitchMask>().SetMask(maskCollected);
        }
    }
#endregion

    public void getFinalMask()
    {
        finalBlowUi.SetActive(true);
        maskCollected = 3;
        gameObject.GetComponent<SwitchMask>().SetMask(maskCollected);
    }
}
