using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBlow : MonoBehaviour
{
    public int damage = 100;
    public float destory = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)//set your collider box to istrigger (for the target enemy)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Debug.Log(collision.name);
            collision.gameObject.GetComponent<Enemy>().CalculateHealth(damage);
        }
        if (collision.gameObject.tag == "CatEnemy")
        {
            Debug.Log(collision.name);
            StartCoroutine(collision.GetComponent<EnemyCat>().EnemyTakeDamage(-damage));
        }
    }
}
