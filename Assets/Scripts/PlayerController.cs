using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 3.0f;
    public float JumpForce = 10f;
    public bool isGrounded = true;
    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    public void PlayerControl()
    {
        //if collide den cannot press
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-(Speed), rb.velocity.y);
            //gameObject.transform.Translate(new Vector2(-1.0f, 0.0f) * Time.deltaTime * Speed);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //anim.SetBool("running", true);
            //gameObject.transform.localScale =new Vector2(-1, 1);
        } else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            //gameObject.transform.Translate(new Vector2(1.0f, 0.0f) * Time.deltaTime * Speed);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //anim.SetBool("running", true);
            //gameObject.transform.localScale = new Vector2(1, 1);
        } else
        {
            //anim.SetBool("running", false);
        }

        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                //gameObject.transform.Translate(new Vector2(0.0f, 1.0f) * Time.deltaTime * Speed);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Touch Ground ");
            isGrounded = true;
        }
    }
}
