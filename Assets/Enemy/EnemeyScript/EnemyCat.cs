using System.Collections;
using UnityEngine;

public class EnemyCat : Characther
{
    private IEnemyState currentState;
    public GameObject Target { get; set; }
    [SerializeField]
    private float meleeRange;
    private float cd = 5;
    private float cdTimer;

    public GameObject expPrefab;
    public GameObject expTarget;
    public SpriteRenderer sprite;
    private ParticleSystem bloodEffect;

    public static bool hitshuriken;
    private bool enemyDied;

   
    public bool InMeleeRange
    {
        get
        {
            if(Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
            }
            return false;
        }
    }
    public override bool IsDead
    {
        get
        {
            
            return health <= 0;
            
        }
    }
    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
        enemyDied = false;
        expTarget = GameObject.FindGameObjectWithTag("ExpTag");
        bloodEffect = gameObject.GetComponentInChildren<ParticleSystem>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;
            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }
    void Update()
    {
        if (!IsDead) 
        {               
            if (!TakingDamage)
            {
                currentState.Execute();
            }
            enemyDied = true;
            LookAtTarget();
        }
        else
        {
            cdTimer += Time.deltaTime;
            if (cdTimer >= cd)
            {
                Destroy(gameObject);
            }
        }
        //if(Input.GetKeyDown(KeyCode.M))
        //{
        //    StartCoroutine(TakeDamage());
        //}
    }
    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }
    public void Move()
    {
        if (!Attack)
        {
            MyAnimator.SetFloat("Espeed", 1);
            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
        }
    }
    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }
    //public override IEnumerator TakeDamage()
    //{
    //    health -= 10;
    //    if(!IsDead)
    //    {
    //        MyAnimator.SetTrigger("Edmg");
    //    }
    //    else
    //    {
    //        MyAnimator.SetTrigger("Edie");
    //        yield return null;
    //    }
    //}
    public IEnumerator EnemyTakeDamage(int dmg)
    {
        health += dmg;
        if (dmg < 0)
        {
            StartCoroutine(FlashRed());
        }
        if (!IsDead)
        {
            MyAnimator.SetTrigger("dmg");
        }
        else
        {
            //Debug.Log("im dead bruh");
            MyAnimator.SetTrigger("dead");
            shuriken.enemydefeated = true;
            enemyDied = true;
            chestopener.enemycount += 1;
            chestopener1.enemycount += 1;
            //Debug.Log(chestopener1.enemycount);
            //Debug.Log("enemy counter: " + chestopener.enemycount);
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //gameObject.GetComponentInChildren<EdgeCollider2D>().enabled = false;
            gameObject.layer = 9;

            var go = Instantiate(expPrefab, transform.position + new Vector3(1,5), Quaternion.identity);
            go.GetComponent<FollowPlyr>().Target = expTarget.transform ;
            //create bool for exp spawn here


            yield return null;
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);

        //if (other.gameObject.CompareTag("shuriken"))
        //{
        //    enemyDied = true;
        //    shuriken.shurikenshoot = true;
        //    Debug.Log("enemyhit shuriken");
        //}
    }

    //void setshurikenfalse()
    //{
    //    hitshuriken = false;
    //}

    public IEnumerator FlashRed()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        sprite.color = Color.red;
        bloodEffect.Play();
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
