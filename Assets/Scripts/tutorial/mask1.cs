using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask1 : MonoBehaviour
{
    public GameObject mask1popup;
    bool maskactive=false;
    // Start is called before the first frame update
    void Start()
    {
        mask1popup.SetActive(false);
        maskactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (maskactive==false)
        {
            if (chestopener1.obtainedkey)
            {
                Invoke("setmaskactive", 0.5f);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    maskactive = true;
                    if (maskactive)
                    {
                        Invoke("setmaskactivefalse", 0.5f);
                    }

                }
            }
        }
        
    }

    void setmaskactive()
    {
        mask1popup.SetActive(true);
    }

    void setmaskactivefalse()
    {
        mask1popup.SetActive(false);
    }
}
