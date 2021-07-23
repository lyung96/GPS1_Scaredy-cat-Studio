using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePopUpInstructions: MonoBehaviour
{
    public GameObject MovementInstructions;
    public GameObject Collider;
    public GameObject DashInstructions;
    public GameObject JumpInstructions;
    public GameObject AttackInstructions;
    public GameObject ShurikenInstructions;
    public GameObject GrappleInstructions;
    public static bool left = false;
    public static bool right = false;
    public static bool dash = false;
    public static bool jump = false;
    public static bool attack = false;
    public static bool shuriken = false;
    public static bool grap = false;
    public static bool entertutorialarea = false;
    // Start is called before the first frame update
    void Start()
    {
        MovementInstructions.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = true;
            Debug.Log("Collision");
            MovementInstructions.SetActive(true);
            if (left && right)
            {
                MovementInstructions.SetActive(false);
                if (dash)
                {
                    DashInstructions.SetActive(false);
                    if (jump)
                    {
                        JumpInstructions.SetActive(false);
                        if (attack)
                        {
                            AttackInstructions.SetActive(false);
                            if (shuriken)
                            {
                                ShurikenInstructions.SetActive(false);
                                if (grap)
                                {
                                    GrappleInstructions.SetActive(false);
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = true;
            if (Input.GetKey(KeyCode.A))
            {
                left = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                right = true;
            }
            if (left && right)
            {
                //Debug.Log("Movement Fullfilled");
                Invoke("MovePopoff", 0.5f);
                Invoke("DashPopup", 0.5f);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    dash = true;
                }
                if (dash)
                {
                    //Debug.Log("Dash Fullfilled");
                    Invoke("DashPopoff", 0.5f);
                    Invoke("JumpPopup", 0.5f);
                    if (Input.GetKey(KeyCode.Space))
                    {
                        jump = true;
                    }
                    if (jump)
                    {
                        //Debug.Log("Jump Fullfilled");
                        Invoke("JumpPopoff", 0.5f);
                        Invoke("AttackPopup", 0.5f);
                        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
                        {
                            attack = true;
                        }
                        if (attack)
                        {
                            //Debug.Log("Attack Fullfilled");
                            Invoke("AttackPopoff", 0.5f);
                            Invoke("ShurikenPopup", 0.5f);
                            if (Input.GetKey(KeyCode.R))
                            {
                                shuriken = true;
                            }
                            if (shuriken)
                            {
                                Invoke("ShurikenPopoff", 0.5f);
                                Invoke("GrapplePopup", 0.5f);
                                if (grap)
                                {
                                    //Debug.Log("Grap Fullfilled");
                                    Invoke("GrapPopoff", 0.5f);

                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = false;
            Debug.Log("Exit Collision");
            if (left && right && dash && jump && attack && grap)
            {
                left = false;
                right = false;
                dash = false;
                jump = false;
                attack = false;
                shuriken = false;
                grap = false;
                Destroy(Collider);
            }
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

    private void MovePopoff()
    {
        MovementInstructions.SetActive(false);
    }
    private void DashPopoff()
    {
        DashInstructions.SetActive(false);
    }

    private void DashPopup()
    {
        DashInstructions.SetActive(true);
    }

    private void JumpPopup()
    {
        JumpInstructions.SetActive(true);
    }

    private void JumpPopoff()
    {
        JumpInstructions.SetActive(false);
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

    private void Update()
    {
    }
}


