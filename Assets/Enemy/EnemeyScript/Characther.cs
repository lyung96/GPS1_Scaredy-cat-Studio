using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characther : MonoBehaviour
{
    protected bool facingRight;
    [SerializeField]
    protected float movementSpeed;    
    [SerializeField]
    protected int health;
    public bool Attack { get; set; }
    public abstract bool IsDead { get; }
    public bool TakingDamage { get; set; }
    public Animator MyAnimator { get; private set; }
    [SerializeField]
    private EdgeCollider2D SwordCollider;
    [SerializeField]
    public virtual void Start()
    {
        facingRight = !facingRight;
        MyAnimator = GetComponent<Animator>();
    }
    void Update()
    {        
    }
    //public abstract IEnumerator TakeDamage();
    public void ChangeDirection()
    {
        //Debug.Log("switching");
        facingRight = !facingRight;
        //transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }
    public virtual void MeleeAttack()
    {
        SwordCollider.enabled = !SwordCollider.enabled;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        if (SwordCollider.enabled)
    //        {
    //            Debug.Log(collision.name);
    //            collision.gameObject.GetComponent<PlayerController>().CalHp(-1);
    //        }
    //    }
    //}
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        //if (damageSources.Contains(other.tag)) //if the damagesources contains this tag then call coroutine
        //{
        //    StartCoroutine(TakeDamage());
        //}
        //other way to implement this is
        //if (other.tag == "knife")
        //{
        //    StartCoroutine(TakeDamage());
        //}
        if (other.gameObject.CompareTag("Player"))
        {
            if (SwordCollider.enabled)
            {
                Debug.Log(other.name);
                other.gameObject.GetComponent<PlayerController>().CalHp(-1);
            }
        }

    }
}
