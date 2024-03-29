using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RangedState : IEnemyState
{
    private EnemyCat enemy;
    public void Enter(EnemyCat enemy)
    {
        this.enemy = enemy;
    }
    public void Execute()
    {
        if(enemy.InMeleeRange)
        {
            enemy.ChangeState(new MeleeState());
        }
        else if (enemy.Target != null)
        {            
            enemy.Move();
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
    }
    public void Exit()
    {
    }
    public void OnTriggerEnter(Collider2D other)
    {
    }    
}
