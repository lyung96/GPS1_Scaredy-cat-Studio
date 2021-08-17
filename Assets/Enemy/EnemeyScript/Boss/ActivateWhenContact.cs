using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhenContact : MonoBehaviour
{

    [SerializeField] private Boss Bboss;
    public bool ActivatedBoss;
    void Start()
    {
        Bboss.enabled = false;
        ActivatedBoss = false;
    }

    private void OnTriggerEnter2D(Collider2D Hit)
    {
        Debug.Log("Collide with the :" + Hit.gameObject.name + "now the bool is :" + ActivatedBoss);
        if (Hit.gameObject.tag == "activate")
        {
            if (Hit is CircleCollider2D)
            {
                ActivatedBoss = true;
                Bboss.enabled = true;
                Debug.Log("Collide the im in :" + Hit.gameObject.name + "now the bool is :" + ActivatedBoss);
            }
        }
    }

}
