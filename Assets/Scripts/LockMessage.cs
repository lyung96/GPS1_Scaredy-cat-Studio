using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMessage : MonoBehaviour
{
    public GameObject lockmessage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lockmessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lockmessage.SetActive(false);
        }
    }
}
