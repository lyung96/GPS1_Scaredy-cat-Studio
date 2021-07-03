using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPopup : MonoBehaviour
{
    public GameObject AttackInstructions;
    public GameObject GrappleInstructions;
    public GameObject Collider;
    public static bool attack = false;
    public static bool grap = false;
    // Start is called before the first frame update
    void Start()
    {
        AttackInstructions.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Collision");
            AttackInstructions.SetActive(true);
            if (attack)
            {
                AttackInstructions.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                attack= true;
            }
            if (attack)
            {
                Debug.Log("Attack Fullfilled");
                Invoke("AttackPopoff", 0.5f);
                Invoke("GrapplePopup", 0.5f);
                if (Input.GetMouseButtonDown(1) && Input.GetMouseButton(1))
                {
                    grap = true;

                }
                if (grap)
                {
                    Debug.Log("Grap Fullfilled");
                    Invoke("GrapPopoff", 0.5f);
                }
            }
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            Debug.Log("Exit Attack Collision");
            if (attack && grap)
            {
                Destroy(Collider);
            }
        }
       
    }

    private void AttackPopoff()
    {
        AttackInstructions.SetActive(false);
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


