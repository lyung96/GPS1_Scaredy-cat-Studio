using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestopener : MonoBehaviour
{
    public GameObject chest, openinstructions, defeatenemyinstructions, obtainedkeyInstructions, interacticon;
    public Enemy enemy;
    public static bool chestopen=false;
    public static bool playerinchestrange = false;
    public static bool obtainedkey = false;
    public static int enemycount=0;
    // Start is called before the first frame update
    void Start()
    {
        chest.SetActive(true);
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V) && playerinchestrange)
        {
            if (enemycount == 4)
            {
                chestopen = true;
                Debug.Log("Open chest");
                GetComponent<Animator>().SetTrigger("Open");
                interacticon.SetActive(false);
                obtainedkey = true;
                if (obtainedkey)
                {
                    obtainedkeyInstructions.SetActive(true);
                    Invoke("keypopoff", 1f);
                }
            }
            else if (enemycount != 4)
            {
                chestopen = false;
                defeatenemyinstructions.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            playerinchestrange = true;
            Debug.Log("Chest touched");
            interacticon.SetActive(true);
                
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerinchestrange = true;
        } 
    }

    private void keypopoff()
    {
        Debug.Log("off");
        obtainedkeyInstructions.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerinchestrange = false;
            if (chestopen == false && enemycount != 4)
            {
                interacticon.SetActive(false);
                defeatenemyinstructions.SetActive(false);
            }
            if (chestopen)
            {
                Destroy(interacticon);
                Destroy(defeatenemyinstructions);
            }

        }
    }
}
