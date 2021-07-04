using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private EnemyCat enemy;

    private float patrolTimer;
    private float patrolDuration = 10;
    public void Enter(EnemyCat enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("patrolling");
        Patrol();

        enemy.Move();

        if (enemy.Target != null && enemy.InThrowRange)
        {
            enemy.ChangeState(new RangedState());

        }
    }

    public void Exit()
    {
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "edge")
        {
            enemy.ChangeDirection();
        }
    }

    private void Patrol()
    {

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }


}
