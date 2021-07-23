using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    private PlatformEffector2D effector;
    //public float waitTime;
    private bool isFalling = false;
    public static bool isGrap;
    public static bool onTop;
    Grapple grappleScript;
    public GameObject player;
    public float offSetX;
    public float offSetY;

    private void Start()
    {
        player = GameObject.Find("Player");
        grappleScript = player.GetComponent<Grapple>(); 
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            //waitTime = 0.1f;
            isFalling = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //waitTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //if (waitTime <= 0)
                //{
                    effector.rotationalOffset = 180f;
                //waitTime = 0.1f;
                    isGrap = false;
                    isFalling = true;
                //}
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isFalling == false))
        {
            effector.rotationalOffset = 0;
            isGrap = false;
        }

        if(Input.GetMouseButtonDown(1))
        {
            isGrap = true;
        }
        if(onTop == true)
        {
            grappleScript.Detatch();
        }
    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player") && (isGrap == true))//&& (onTop == false)
            {
            isGrap = false;
            collision.rigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector2(collision.gameObject.transform.position.x, gameObject.transform.position.y + 2 + offSetY);
            grappleScript.Detatch();
            MovePopUpInstructions.grap = true;
            Debug.Log("Triggered Grappling Point");
            }
    }
}
