using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public static bool hitshuriken;
    bool triggerstun;
    public EnemyCat stunenemy;
    public float timer=0;
    float counter=0;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("shuriken"))
        {
            triggerstun = true;
            stunenemy.GetComponent<EnemyCat>().enabled = false;
            anim.Play("EnemyIdle");
            Debug.Log(anim);
            Invoke("setstunfalse", timer);
            shuriken.shurikenshoot = true;
            Debug.Log("enemyhit shuriken");
        }
    }
    //private void Update()
    //{
    //    timer = Time.deltaTime;
    //    if (triggerstun)
    //    {
            
    //    }
    //}


    void setstunfalse()
    {
        stunenemy.GetComponent<EnemyCat>().enabled = true;
       
    }

    void setshurikenfalse()
    {
        hitshuriken = false;
    }
}
