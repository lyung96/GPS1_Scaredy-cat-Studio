using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairsfalling : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        Debug.Log("Stairs touched");
    //    }
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Stairs touched"); 
      
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            if (PlayerController.left || PlayerController.right || PlayerController.dash)
            {
                //Debug.Log("This is the constraint: " + Player.GetComponent<Rigidbody2D>().constraints);
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                //Player.GetComponent<Rigidbody2D>().gravityScale = 0;
                //Player.GetComponent<PlayerController>().Speed = 5.0f;
            }
            else if (PlayerController.jump  && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.Space))
            {
                //Player.GetComponent<Rigidbody2D>().gravityScale = 10;
            }
            else
            {
                //Player.GetComponent<Rigidbody2D>().gravityScale = 10;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Stairs untouched");
            //Player.GetComponent<Rigidbody2D>().gravityScale = 10;
            //Player.GetComponent<PlayerController>().Speed = 3.0f;

        }
    }

}
