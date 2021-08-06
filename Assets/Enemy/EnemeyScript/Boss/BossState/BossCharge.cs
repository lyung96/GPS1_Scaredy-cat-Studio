using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : IBoss
{
    private Boss Bboss;
    private float ChargeTimer;
    private float ChargeCd;
    
    public void Enter(Boss Bboss)
    {
        this.Bboss = Bboss;
    }

    public void Execute()
    {
        ChargedAttack();
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void ChargedAttack()
    {

        ChargeTimer += Time.deltaTime;
        if (ChargeTimer >= ChargeCd)
        {
            //Bboss.anim.SetTrigger("ChrgAtk"); // we dont have this animation yet.
            Debug.Log("charged attack deployed");
            Bboss.ChangeState(new BossIdle());
        }
    }
}
