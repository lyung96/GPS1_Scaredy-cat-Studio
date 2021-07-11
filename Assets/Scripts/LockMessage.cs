using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMessage : MonoBehaviour
{
    public GameObject lockmessage, unlockmessage, Lock, lockedDoor, openDoor, interacticon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interacticon.SetActive(true);
            //lockmessage.SetActive(true);
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (chestopener.obtainedkey == true)
                {
                    unlockmessage.SetActive(true);
                    lockmessage.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (chestopener.obtainedkey == true)
            {
                if (Input.GetKey(KeyCode.V))
                {
                    Destroy(Lock);
                    lockedDoor.SetActive(false);
                    openDoor.SetActive(true);
                }
            }
            else if (chestopener.obtainedkey== false)
            {
                if (Input.GetKey(KeyCode.V))
                {
                    lockmessage.SetActive(true);
                    unlockmessage.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interacticon.SetActive(false);
            lockmessage.SetActive(false);
            if (chestopener.obtainedkey)
            {
                unlockmessage.SetActive(false);
            }
        }
    }
}
