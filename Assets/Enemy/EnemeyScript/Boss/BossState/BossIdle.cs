using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : IBoss
{
    private Boss Bboss;
    private float BossIdleTimer;
    private float BossIdleCd = 3;

    public void Enter(Boss Bboss)
    {
        this.Bboss = Bboss;
    }

    public void Execute()
    {
        Debug.Log("the boss is idling");
        BossIdling();
        Bboss.FacingPlayer();
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void BossIdling()
    {
        BossIdleTimer += Time.deltaTime;
        if (BossIdleTimer >= BossIdleCd)
        {
            Bboss.ChangeState(new BossMove());
        }
    }
}


