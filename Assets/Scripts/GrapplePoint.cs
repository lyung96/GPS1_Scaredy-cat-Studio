using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    private PlatformEffector2D effector;
    //public float waitTime;
    private bool isFalling = false;
    public bool isGrap;
    //private bool onTop;
    Grapple grappleScript;
    public GameObject player;

    private void Start()
    {
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
    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Check1");
            if (collision.gameObject.CompareTag("Player") && (isGrap == true))//&& (onTop == false)
            {
            collision.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 3);
            grappleScript.Detatch();
            MovePopUpInstructions.grap = true;
            isGrap = false;

            Debug.Log("Triggered Grappling Point");
            }
    }


    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //onTop = false;
        }
    }

}
