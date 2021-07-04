using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characther : MonoBehaviour
{
    public PlayerController playerrr;

    [SerializeField]
    protected Transform knifePos;

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    [SerializeField]
    private GameObject knifePrefab;

    [SerializeField]
    protected int health;

    [SerializeField]
    private EdgeCollider2D SwordCollider;

    [SerializeField]
    private List<string> damageSources;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }

    public Animator MyAnimator { get; private set; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        //Debug.Log("im idling characther");
        playerrr.GetComponent<PlayerController>();
        facingRight = true;
        //facingRight = !facingRight;

        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract IEnumerator TakeDamage();

    public void ChangeDirection()
    {
        facingRight = !facingRight;

        //transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }

    public virtual void ThrowKnife(int value)
    {
        if(facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Knife>().Initialize(Vector3.right); 
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            tmp.GetComponent<Knife>().Initialize(Vector3.left);
        }
    }

    public virtual void MeleeAttack()
    {
        SwordCollider.enabled = true;
        playerrr.CalHp(3f); //player call for hp.
        
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSources.Contains(other.tag)) 
        {
            StartCoroutine(TakeDamage());
        }
    }



}
