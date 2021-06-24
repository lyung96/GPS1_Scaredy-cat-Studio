using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    //public GameObject player;
    //public float direction;
    public int damage = 1;
    public float speed = 30.0f;
    public Rigidbody2D rb;
    private float rotate = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 2.0f);
    }

    private void Update()
    {
        rotate += rotate;
        gameObject.transform.Rotate(0f, 0f, rotate);
    }

    private void OnTriggerEnter2D(Collider2D collision)//set your collider box to istrigger (for the target enemy)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.name);
            collision.gameObject.GetComponent<Enemy>().CalculateHealth(damage);
            Destroy(this.gameObject);

        }
    }

    /*public void SpawnShuriken(float direction)
    {
        GameObject newShuriken = Instantiate(gameObject, player.transform.position, Quaternion.identity);
        if (direction > 0)
        {
            newShuriken.transform.Translate(new Vector2(1.0f, 0.0f) * Time.deltaTime * speed);
        }
        else
        {
            newShuriken.transform.Translate(new Vector2(-1.0f, 0.0f) * Time.deltaTime * speed);
        }
    }*/

    /*private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }*/
}
