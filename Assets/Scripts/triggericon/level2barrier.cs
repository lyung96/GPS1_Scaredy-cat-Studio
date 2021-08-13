using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2barrier : MonoBehaviour
{
    bool trigger=false, stay=false;
    public GameObject icon;
    public static bool startdialogue;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
        stay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            startdialogue = true;
            icon.SetActive(true);
        }
        else
        {
            startdialogue = false;
            icon.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
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
            trigger = false;
            stay = false;
        }
      
    }
}
