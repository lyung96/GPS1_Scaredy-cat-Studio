using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3bosscut : MonoBehaviour
{
    public static bool triggerdialogue, enterdialogue, exitdialogue, startdialogue;
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
        cameraanim.SetBool("Cutscene1", true);
        Invoke("stopcutscene", 1.0f);

    }
    void stopcutscene()
    {
        cameraanim.SetBool("Cutscene1", false);
        enterdialogue = false;
        triggerdialogue = false;
        startdialogue = true;
    }

    private void Update()
    {
        if (enterdialogue == true || triggerdialogue == true)
        {
            startcutscene();

        }
        else if (exitdialogue == true)
        {
            Destroy(gameObject);
        }
    }
}
