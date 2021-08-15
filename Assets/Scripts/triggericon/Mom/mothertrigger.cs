using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothertrigger : MonoBehaviour
{
    public static bool triggerrange, inrange;
    public GameObject icon;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerrange = true;
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            inrange = true;
        }


    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerrange = false;
            inrange = false;
        }


    }

    private void Start()
    {
    }
    private void Update()
    {

        if (Boss.health<=0)
        {
            if (triggerrange)
            {
                icon.SetActive(true);
            }
            else if (inrange)
            {
                icon.SetActive(true);

            }
            else if (triggerrange == false && inrange == false)
            {
                icon.SetActive(false);
            }
        }
        

    }
}
