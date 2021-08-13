using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskfrag : MonoBehaviour
{
    public Animator maskanim;
    // Start is called before the first frame update
    void Start()
    {
        maskanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (chestopener1.playerinchestrange)
            {
                if (chestopener1.enemycount >= 3)
                {
                    maskanim.SetTrigger("idle");
                    Invoke("setmaskanimoff", 2f);
                }
            }
        }
    }

    void setmaskanimoff()
    {
        maskanim.SetTrigger("exit");
        Invoke("offfrag", 3f);
    }

    void offfrag()
    {
        gameObject.SetActive(false);
    }
}
