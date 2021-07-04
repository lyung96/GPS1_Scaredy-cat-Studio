using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{

    private EnemyCat enemy;

    private float idleTimer;

    private float idleDuration = 5;
    public void Enter(EnemyCat enemy)
    {
        this.enemy = enemy;
    }


    public void Execute()
    {
        Debug.Log("im idling");

        Idle();

        if (enemy.Target != null)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
    }

    public void OnTriggerEnter(Collider2D other)
    {
    }

    private void Idle()
    {
        enemy.MyAnimator.SetFloat("Espeed", 0);

        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

}
