using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestopener : MonoBehaviour
{
    public GameObject chest, openinstructions, defeatenemyinstructions, obtainedkeyInstructions;
    public Enemy enemy;
    public static bool chestopen=false;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            Debug.Log("Chest touched");
            if (enemycount!=4 && chestopen==false)
            {
                defeatenemyinstructions.SetActive(true);
                openinstructions.SetActive(false);
            }
            if(enemycount >= 3 && chestopen== false)
            {
                openinstructions.SetActive(true);
                defeatenemyinstructions.SetActive(false);

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.V))
        {
            chestopen = true;
            if(chestopen && enemycount >=4)
            {
                Debug.Log("Open chest");
                GetComponent<Animator>().SetTrigger("Open");
                openinstructions.SetActive(false);
                obtainedkey = true;
                if (obtainedkey)
                {
                    obtainedkeyInstructions.SetActive(true);
                    Invoke("keypopoff", 1f);
                }
            }
          

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
            if (chestopen==false && enemycount <=2)
            {
                openinstructions.SetActive(false);
            }
            if (chestopen == false && enemycount >= 3)
            {
                defeatenemyinstructions.SetActive(false);
            }
            if (chestopen)
            {
                Destroy(openinstructions);
                Destroy(defeatenemyinstructions);
            }

        }
    }
}
