using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenController : MonoBehaviour
{
    public int maxShuriken;
    public int shuriken;
    public int numOfShuriken;



    public Sprite readyshuriken;
    public Sprite emptyShuriken;

    public Image[] shurikens;
    void Start()
    {
        shuriken = maxShuriken;
    }
    // Update is called once per frame
    void Update()
    {
        if (shuriken > numOfShuriken)
        {
            shuriken = numOfShuriken;
        }

        for (int i = 0; i < shurikens.Length; i++)
        {

            if (i < numOfShuriken)
            {
                shurikens[i].enabled = true;
            }
            else
            {
                shurikens[i].enabled = false;
            }

            if ( i < shuriken)
            {
                shurikens[i].sprite = readyshuriken;
            }
            else
            {
                shurikens[i].sprite = emptyShuriken;
            }
        }

    }
    public void UseShuriken()
    {
        if (shuriken > 0)
        {
            shuriken--;

            if (shuriken <= 0)
            {
                shuriken = 0;
            }
        }
    }


}
