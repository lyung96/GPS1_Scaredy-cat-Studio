using System.Collections;
using UnityEngine;

public class EnemyCat : Characther
{
    //enemy current state, changing this will change the behavior of the enemy
    private IEnemyState currentState;

    //enemy target
    public GameObject Target { get; set; }

    //enemy melee range, at what range does it need to use the sword
    [SerializeField]
    private float meleeRange;

    //enemy throwing range, how far can it starts throwing knifes
    [SerializeField]
    private float throwRange;

    //check if the enemy is in melee range
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

    //indicates if the enemy is in throwing range
    public bool InThrowRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;
            }
            return false;
        }
    }

    //indicates if the enemy is dead
    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        //calls the base start. base is the root of the start function which is coded in the characther script
        base.Start();

        //makes the RemoveTarget function listen to the player Dead event
        //Player.Instance.Dead += new DeadEventHandler(RemoveTarget);

        //sets the enemy in idle state
        ChangeState(new IdleState());
    }

    

    // Update is called once per frame
    void Update()
    {
        if(!IsDead) //if enemy is alive
        {               //and
            if(!TakingDamage)//if the enemy is not taking any damage 
            {
                //execute the current state. this can make the enemy move or attack etc.
                currentState.Execute();
            }
            //makes the enemy look at the target
            LookAtTarget();
        }

    }
    //removest the enemy target. so that it stops killing the dead player
    public void RemoveTarget()
    {

    }

    //enemy looks at target
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

    //changing the enemy states
    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    //moving the player
    public void Move()
    {
        if (!Attack)
        {
            MyAnimator.SetFloat("Espeed", 1);
            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
        }
    }

    //
    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);
    }

    public override IEnumerator TakeDamage()
    {
        health -= 10;

        if(!IsDead)
        {
            MyAnimator.SetTrigger("Edmg");
        }
        else
        {
            MyAnimator.SetTrigger("Edie");
            yield return null;
        }

    }
}
