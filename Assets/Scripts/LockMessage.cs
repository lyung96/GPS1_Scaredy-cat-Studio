using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMessage : MonoBehaviour
{
    public GameObject lockmessage, unlockmessage, Lock, lockedDoor, openDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lockmessage.SetActive(true);
            if(chestopener.obtainedkey== true)
            {
                unlockmessage.SetActive(true);
                lockmessage.SetActive(false);
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lockmessage.SetActive(false);
            if (chestopener.obtainedkey)
            {
                unlockmessage.SetActive(false);
            }
        }
    }
}
