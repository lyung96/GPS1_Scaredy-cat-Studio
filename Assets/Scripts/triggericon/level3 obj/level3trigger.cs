using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3trigger : MonoBehaviour
{
    public static bool trigger=false,exit=false;

    private void Start()
    {
        trigger = false;
        exit = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            trigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            exit = true;
        }
    }

    private void Update()
    {
        if (exit== true)
        {
            Destroy(gameObject);
        }
    }
}
