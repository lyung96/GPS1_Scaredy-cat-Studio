using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuriken : MonoBehaviour
{
    public GameObject AttackInstructions;
    public GameObject ShurikenInstructions;
    public bool playerinrange=false;
    public bool playertriggerrange = false;
  
    public static bool enemydefeated = false;
    public static bool shurikenshoot = false;
    public GameObject GrappleInstructions;
    // Start is called before the first frame update
    void Start()
    {
        shurikenshoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playertriggerrange)//enter
        {

            if (MovePopUpInstructions.grap == false)
            {
                Debug.Log("shuriken popoon");
                ShurikenPopup();
            }
            if (shurikenshoot)
            {
                Invoke("ShurikenPopoff", 0f);
                if (enemydefeated)
                {
                    Invoke("AttackPopoff", 0f);
                    if (MovePopUpInstructions.grap)
                    {
                        Invoke("GrapPopoff", 0f);
                    }
                }
            }
        }


        if (playerinrange)//stay
        {
            if (shurikenshoot)
            {
                Invoke("ShurikenPopoff", 0.5f);
                AttackPopup();
                if (enemydefeated)
                {
                    Invoke("AttackPopoff", 0.5f);
                    GrapplePopup();
                    if (MovePopUpInstructions.grap)
                    {
                        enemydefeated = false;
                        shurikenshoot = false;
                        MovePopUpInstructions.jump = false;
                        MovePopUpInstructions.dash = false;
                        MovePopUpInstructions.right = false;
                        MovePopUpInstructions.left = false;
                        Debug.Log("grap off");
                        Invoke("GrapPopoff", 0.5f);
                    }

                }
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            playertriggerrange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerinrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerinrange = false;
        playertriggerrange = false;
        if (shurikenshoot && enemydefeated && MovePopUpInstructions.grap)
        {
            shurikenshoot = false;
            enemydefeated = false;
            MovePopUpInstructions.grap = false;
        }
    }


    private void ShurikenPopup()
    {
        ShurikenInstructions.SetActive(true);
    }

    private void ShurikenPopoff()
    {
        ShurikenInstructions.SetActive(false);
    }

    private void AttackPopoff()
    {
        AttackInstructions.SetActive(false);
    }
    private void AttackPopup()
    {
        AttackInstructions.SetActive(true);
    }
    private void GrapplePopup()
    {
        GrappleInstructions.SetActive(true);
    }

    private void GrapPopoff()
    {
        GrappleInstructions.SetActive(false);
    }
}
