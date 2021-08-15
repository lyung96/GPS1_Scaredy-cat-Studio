using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startbosscut : MonoBehaviour
{
    public static bool triggerdialogue, enterdialogue, exitdialogue;
    public Animator cameraanim;
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
            exitdialogue = true;
        }
    }

    void startcutscene()
    {
        cameraanim.SetBool("Bosscutscene", true);
        Invoke("stopcutscene", 1.0f);
       
    }
    void stopcutscene()
    {
        cameraanim.SetBool("Bosscutscene", false);
        enterdialogue = false;
        triggerdialogue = false;
    }

    private void Update()
    {
        if (enterdialogue==true || triggerdialogue==true)
        {
            startcutscene();
           
        }
        else if (exitdialogue==true)
        {
            Destroy(gameObject);
        }
    }
}
