using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestopener : MonoBehaviour
{
    public GameObject chest, defeatenemyinstructions, obtainedkeyInstructions, interacticon;
    public Enemy enemy;
    public static bool chestopen=false;
    public static bool playerinchestrange = false, playertriggerchest=false;
    public static bool obtainedkey = false, dialoguestart=false, enemydialoguestart=false;
    public static int enemycount=0;
    public int maxcounter=2;
    public obtainedkey key;
    // Start is called before the first frame update
    void Start()
    {
        enemycount = 0;
        obtainedkey = false;
        chest.SetActive(true);
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (playerinchestrange)
            {
                if (enemycount >= maxcounter)
                {
                    chestopen = true;
                    Debug.Log("Open chest");
                    GetComponent<Animator>().SetTrigger("Open");
                    interacticon.SetActive(false);
                    obtainedkey = true;
                    if (chestopen && playerinchestrange)
                    {
                        dialoguestart = true;
                    }
                }
                else if (enemycount < maxcounter)
                {
                    if (chestopen==false && playerinchestrange)
                    {
                        enemydialoguestart = true;
                        Debug.Log("enemystartdialogue");
                    }
                }
            }    
        }

      


        if (playertriggerchest)
        {
            if (obtainedkey==false)
            {
                interacticon.SetActive(true);
            }
            else if(obtainedkey && chestopen)
            {
                interacticon.SetActive(false);
            }
        }

        if (playerinchestrange==false && playertriggerchest==false)
        {
            if (obtainedkey==false)
            {
                interacticon.SetActive(false);
            }
            else if (obtainedkey)
            {
                interacticon.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            playertriggerchest = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerinchestrange = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playertriggerchest = false;
            playerinchestrange = false; 
        }
    }
}
