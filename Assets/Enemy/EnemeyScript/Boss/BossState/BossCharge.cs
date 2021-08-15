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
        Debug.Log("charge atk");
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
            Bboss.anim.SetTrigger("Charge");
            Debug.Log("charged attack deployed");
            Bboss.ChangeState(new BossIdle());
        }
    }
}
