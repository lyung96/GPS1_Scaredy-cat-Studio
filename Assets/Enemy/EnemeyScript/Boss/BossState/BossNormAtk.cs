using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNormAtk : IBoss
{
    private Boss Bboss;
    private float AttackTimer;
    private float AttackCd = 5;
    private bool Attacked = true;
    private int ChargePoints;
    private int ChargePts = 5;
    public void Enter(Boss Bboss)
    {
        this.Bboss = Bboss;
    }

    public void Execute()
    {
        Debug.Log("boss is attacking");
        BossAttacked();
        Bboss.FacingPlayer();
       
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
      
    }

    private void BossAttacked()
    {
        AttackTimer += Time.deltaTime;
        if (AttackTimer >= AttackCd)
        {
            Bboss.anim.SetTrigger("Eattack");
            AttackTimer = 0;
            ChargePoints++;
            if (ChargePoints >= ChargePts)
            {
                ChargePoints = 0;
                Bboss.ChangeState(new BossCharge());
            }
            else
            {
                Bboss.ChangeState(new BossIdle());
            }
        }
      
        //Attacked = false;
        //Debug.Log(Attacked);
    }
 
}

//Goal
//1. launch an attack towards the direction of the player(dont care if player is there or not)
//2. plus a charge counter(for charge attack)
//3. check if the charge attack counter is more than or equal to the charge attack counter set. if yes , switch to charge attack state. if no , switch to idle state
//4. 
