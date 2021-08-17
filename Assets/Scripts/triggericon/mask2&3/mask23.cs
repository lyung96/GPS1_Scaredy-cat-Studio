using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask23 : MonoBehaviour
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
            if (Obtainedmask3.bossdefeat)
            {
                    maskanim.SetTrigger("idle");
                    Invoke("setmaskanimoff", 2f);
            }

    }

    void setmaskanimoff()
    {
        maskanim.SetTrigger("exit");
        //Invoke("offfrag", 4f);
    }

    void offfrag()
    {
        gameObject.SetActive(false);
    }
}
