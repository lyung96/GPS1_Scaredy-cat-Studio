using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMessage : MonoBehaviour
{
    public GameObject lockmessage, Lock, lockedDoor, openDoor, interacticon, dialogbox;
    public static bool doortrigger=false, playerinrange=false, dialoguetrigger=false;

    public void Start()
    {
    } 

    private void Update()
    {
        if (chestopener.obtainedkey == true && playerinrange)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(Lock);
                lockedDoor.SetActive(false);
                openDoor.SetActive(true);
            }
        }
        else if (chestopener.obtainedkey == false && playerinrange)
        {
            dialoguetrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Enter door range");
            playerinrange = true;
            interacticon.SetActive(true);
            doortrigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Enter door range");
            playerinrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Exit door range");
            playerinrange = false;
            interacticon.SetActive(false);
            dialoguetrigger = false;
        }
    }
}
