using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoss
{
    void Execute();
    void Enter(Boss Bboss);
    void OnTriggerEnter(Collider2D other);
    void Exit();
    
}
