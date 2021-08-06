using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : IBoss
{
    private Boss Bboss;
    private float BossMoveTimer;
    private float BossMoveCd = 5;

    public void Enter(Boss Bboss)
    {
        this.Bboss = Bboss;
    }

    public void Execute()
    {
        Debug.Log("the boss is moving");
        BossMoving();
        Bboss.BossMove();
        Bboss.FacingPlayer();
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    private void BossMoving()
    {
        BossMoveTimer += Time.deltaTime;
        if (BossMoveTimer >= BossMoveCd)
        {
            Bboss.ChangeState(new BossNormAtk());
        }
    }
}


//Goal
//1. move the boss towards the player
//2. flip the boss to the player based on location
//3. if timer is more than cd then switch state => normal attack