using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMessage : MonoBehaviour
{
    public GameObject lockmessage, Lock, lockedDoor, openDoor, interacticon, dialogbox;
    public static bool doortrigger=false, playerinrange=false, dialogtrigger=false;
    public Dialog dialog;

    public void Start()
    {
        dialog=GetComponent<Dialog>();
    } 

    private void Update()
    {
        if (chestopener.obtainedkey == true && playerinrange)
        {
            if (Input.GetKey(KeyCode.V))
            {
                Destroy(Lock);
                lockedDoor.SetActive(false);
                openDoor.SetActive(true);
            }
        }
        else if (chestopener.obtainedkey == false && playerinrange)
        {
            Dialog.StartDialogue = true;
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
            Debug.Log("Enter door range");
            playerinrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Exit door range");
            playerinrange = false;
            Dialog.StartDialogue = false;
            interacticon.SetActive(false);
            lockmessage.SetActive(false);
            //if (chestopener.obtainedkey)
            //{
            //}
        }
    }
}
