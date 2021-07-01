using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour
{
    //public int damage = 10;
    //private bool canDamage = true;
    //public Rigidbody2D rb;
    //public float atkRange = 0.5f;
    //public Transform atkPoint;
    //public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        //canDamage = true;
        Destroy(gameObject, 0.7f);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)//set your collider box to istrigger (for the target enemy)
    {
        if (collision.gameObject.tag == "Enemy" && (canDamage == true))
        {
            Debug.Log(collision.name);
            collision.gameObject.GetComponent<Enemy>().CalculateHealth(damage);
            canDamage = false;

        }
    }*/
}
