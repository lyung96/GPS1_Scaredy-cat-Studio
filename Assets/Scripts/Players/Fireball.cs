using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 5;
    public float speed = 30.0f;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 2.0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)//set your collider box to istrigger (for the target enemy)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Debug.Log(collision.name);
            collision.gameObject.GetComponent<Enemy>().CalculateHealth(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag == "CatEnemy")
        {
            Debug.Log(collision.name);
            StartCoroutine(collision.GetComponent<EnemyCat>().EnemyTakeDamage(-damage));
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}


