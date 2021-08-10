using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public IBoss currentState;
    public Transform Target;
    public float Speed ;
    Vector3 Velocity = Vector3.zero;
    public Rigidbody2D rb;
    public Animator anim;
    public bool Attacking { get; set; }
    private float distance;
    [SerializeField]
    public int health;
    public SpriteRenderer sprite;
    private ParticleSystem bloodEffect;
    [SerializeField]
    private EdgeCollider2D SwordCollider;
    public bool PlayerAttacking;
    
    private float DeathTimer;
    [SerializeField]
    private float DeathCd;

    //check if the boss is dead, if yes return true
    public bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }
    //to check if ur the level one jurou, make it true in the inspector if u are jurou for level one.
    //this way u can give the final blow to kill the human form player
    public bool JurouLvlOne;
    //check if the 1st boss is down to desired hp (15)
    public bool JurouLvlOneHp
    {
        get
        {
            return health <= 15;
        }
    }


    void Start()
    {
        ChangeState(new BossIdle());
        anim = gameObject.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (!IsDead)
        {
            if (!PlayerAttacking)
            {
                currentState.Execute();
            }
            FacingPlayer();
        }
        else
        {
            DeathTimer += Time.deltaTime;
            if (DeathTimer >= DeathCd)
            {
                Destroy(gameObject);
            }
        }
    }

    //change the boss state
    public void ChangeState(IBoss newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }
    //move the boss to the player direction
    public void BossMove()
    {
        if (!Attacking)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref Velocity, Speed * Time.deltaTime  );
            anim.SetFloat("Espeed", 1);
            //Debug.Log("player pos is:" + Target.position);
        }
    }
    //looks at players direction
    public void FacingPlayer()
    {
        //Debug.Log("velocity x is :" + rb.velocity.x);
        //i change from if(rb.velocity.x >= 0.01f to a normal maths solution. cuz we are already messing with the velocity when it move, so the velocity wont be stable.
        //plus velocity does not act like speed, velocity builds up from speed. conclusion is , its my physics error.
        //Debug.Log("velocity x is :" + rb.velocity.x);
        distance = transform.position.x - Target.position.x;
        if (distance >= 0.01f)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0f);
        }
        else if (distance <= 0.01f)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0f);
        }
    }
    //recieve damage from player
    public IEnumerator BossTakeDamage(int dmg)
    {
        health += dmg;
        if (dmg < 0)
        {
            StartCoroutine(FlashRed());
        }
        if (!IsDead)
        {
            anim.SetTrigger("dmg");
        }
        else
        {
            anim.SetTrigger("dead"); //if it doesnt play, check ur update. there should be a check to see if the boss is dead
            shuriken.enemydefeated = true;

            //var go = Instantiate(expPrefab, transform.position + new Vector3(1, 5), Quaternion.identity);
            //go.GetComponent<FollowPlyr>().Target = expTarget.transform;
            //needs to instantiate the mask i believe, so im leaving this here once its confirm

            yield return null;
        }
    }
    //flash red when receive damage
    public IEnumerator FlashRed()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        //sprite.color = Color.red;
        //bloodEffect.Play();
        yield return new WaitForSeconds(0.1f);
        //sprite.color = Color.white;
    }

    //Tengu
    //normal atk collider 
    //true
    public void TNormalAtkT()
    {
        //enable the spear collider here, then put it in the animation event
    }
    //normal atk collider 
    //false
    public void TNormalAtkF()
    {
        //enable the spear collider here, then put it in the animation event
    }
    //charge atk collider
    //true
    public void TChargeAtkT()
    {
        //enable the spear collider here, then put it in the animation event
    }
    //charge atk collider
    //false
    public void TChargeAtkF()
    {
        //enable the spear collider here, then put it in the animation event
    }

    //Yurei
    //normal atk collider 
    //true
    public void YNormalAtkT()
    {
        //enable the Claw collider here, then put it in the animation event
    }
    //normal atk collider 
    //false
    public void YNormalAtkF()
    {
        //enable the Claw collider here, then put it in the animation event
    }
    //charge atk collider
    //true
    public void YChargeAtkT()
    {
        //enable the Claw collider here, then put it in the animation event
    }
    //charge atk collider
    //false
    public void YChargeAtkF()
    {
        //enable the Claw collider here, then put it in the animation event
    }

    //Jurou
    //normal atk collider 
    //true
    public void JNormalAtkT()
    {
        //enable the Claw collider here, then put it in the animation event
    }
    //normal atk collider 
    //false
    public void JNormalAtkF()
    {
        //enable the Claw collider here, then put it in the animation event
    }
    //charge atk collider
    //true
    public void JChargeAtkT()
    {
        //enable the Claw collider here, then put it in the animation event
    }
    //charge atk collider
    //false
    public void JChargeAtkF()
    {
        //enable the Claw collider here, then put it in the animation event
    }
    


    //reduce player hp
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        //for now the player cant receive damage cuz we got no swordcollider aka the weapon collider in the animation. waiting for artist
        if (other.gameObject.CompareTag("Player"))
        {
            //Tengu
            //normal damage
            //if (normal attack collider)
            //{
            //    //damage the player by small hp (-1)
            //    other.gameObject.GetComponent<PlayerController>().CalHp(-1);
            //}
            ////charge damage
            //if (charge attack collider)
            //{
            //    //damage the player by big hp (-10)
            //    other.gameObject.GetComponent<PlayerController>().CalHp(-10);
            //}

            //Yurei
            //normal damage
            //if (normal attack collider)
            //{
            //    //damage the player by small hp (-1)
            //    other.gameObject.GetComponent<PlayerController>().CalHp(-1);
            //}
            ////charge damage
            //if (charge attack collider)
            //{
            //    //damage the player by big hp (-10)
            //    other.gameObject.GetComponent<PlayerController>().CalHp(-10);
            //}

            //Jurou
            //normal damage
            if (SwordCollider.enabled) 
            {
                if (JurouLvlOne) //are u jurou in lvl 1?
                {//yes i am
                    if (JurouLvlOneHp) //is ur hp 15 and below?
                    {//yes
                        //give the most damage here
                        other.gameObject.GetComponent<PlayerController>().CalHp(-100); //kill him
                    }
                    else
                    {//no
                        //normal damage here
                        other.gameObject.GetComponent<PlayerController>().CalHp(-1); //damage him
                    }
                }
                else
                {//no im not 
                    //normal damage here
                    other.gameObject.GetComponent<PlayerController>().CalHp(-1); //damage him
                }
            }
            //charge damage
            if (SwordCollider.enabled)//of course this cant be the same swordcollider, later change it like in the manual below
            {
                if (JurouLvlOne) //are u jurou in lvl 1?
                {//yes i am
                    if (JurouLvlOneHp) //is ur hp 15 and below?
                    {//yes
                        //give the most damage here
                        other.gameObject.GetComponent<PlayerController>().CalHp(-100); //kill him
                    }
                    else
                    {//no
                        //normal damage here
                        other.gameObject.GetComponent<PlayerController>().CalHp(-1); //damage him
                    }
                }
                else
                {//no im not 
                    //normal damage here
                    other.gameObject.GetComponent<PlayerController>().CalHp(-1); //damage him
                }
            }
            
            //if claw enable (yurei)
            //do something
            //dmg player
            //
            //if sword collider (jurour)

            //every boss will have 2 collider
            //1. normal attack collider - if statement
            //2. charge attack collider - if statement
            //I.E 
            /*
            if(normal attack collider)
            {
                //damage the player by small hp (-1)
            }
            if (charge attack collider)
            {
                //damage the player by big hp (-10)
            }
            */
            //
            //to make jurou kill the player in the first level
            //1. a bool check to see if he is the level 1 jurou
            //2. if he is, then set a special condition just for him
            //3. if he is not, refer back to "every boss will have 2 collider" manual above
        }
    }
}



//
//
//
//GOAL
//1. make the boss enters and exit the idle state - [done]
//2. make the boss enters and exit the moving state - [done]
//3. make the boss enters and exit the normal attack state - [done]
//4. make the boss enters and exit the charge attack state - [done]
//5. make a hp for  - [done]
//6. make a flash red -[done]
//7. make a function to reduce the boss hp - [done]
//8. make a function to reduce the players hp - [done]
//9. make a function to make the boss flip to the direction of player, so that it wont blindly attack - [done]
//10.
//Debug.Log(other.name);