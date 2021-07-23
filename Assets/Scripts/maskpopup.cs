using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskpopup : MonoBehaviour
{
    public GameObject Mask1Instructions;
    public static bool mask1 = false;
    private static bool entertutorialarea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = false;
        }
    }

    void Update()
    {
        if (entertutorialarea)
        {
            if (mask1==false)
            {
                Mask1Instructions.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                mask1 = true;
                if (mask1)
                {
                    Invoke("mask1popoff", 0.5f);
                }
            }
        }
        else
        {
            //if (mask1==false)
            //{
            //    Mask1Instructions.SetActive(false);
            //}
            
        }
    }

    private void mask1popoff()
    {
        Destroy(Mask1Instructions);
    }
}
