using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1start : MonoBehaviour
{
    public static bool triggerdialogue, enterdialogue;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerdialogue = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            enterdialogue = true;
        }


    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerdialogue = false;
            enterdialogue = false;
        }


    }
}
