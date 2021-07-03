using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestopener : MonoBehaviour
{
    public GameObject chest, openinstructions, defeatenemyinstructions, Lock;
    public Enemy enemy;
    public bool chestopen=false;
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
            if (enemycount!=3 && chestopen==false)
            {
                defeatenemyinstructions.SetActive(true);
                openinstructions.SetActive(false);
            }
            if(enemycount==3 && chestopen== false)
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
            if(chestopen && enemycount==3)
            {
                Debug.Log("Open chest");
                GetComponent<Animator>().SetTrigger("Open");
                openinstructions.SetActive(false);
                Destroy(Lock);

            }
          

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (chestopen==false && enemycount==3)
            {
                openinstructions.SetActive(false);
            }
            if (chestopen == false && enemycount != 3)
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