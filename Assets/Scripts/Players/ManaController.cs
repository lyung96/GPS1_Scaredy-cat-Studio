using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaController : MonoBehaviour
{
    public int maxMana;
    public int currMana;
    public int numOfMana;

    public Sprite fullMana;
    public Sprite emptyMana;

    public Image[] Manas;

    // Start is called before the first frame update
    void Start()
    {
        currMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (currMana > numOfMana)
        {
            currMana = numOfMana;
        }

        for (int i = 0; i < Manas.Length; i++)
        {

            if (i < numOfMana)
            {
                Manas[i].enabled = true;
            }
            else
            {
                Manas[i].enabled = false;
            }

            if (i < currMana)
            {
                Manas[i].sprite = fullMana;
            }
            else
            {
                Manas[i].sprite = emptyMana;
            }
        }
    }
    public void UseMana(int mana)
    {
        if (currMana > 0)
        {
            currMana += mana;

            if (currMana <= 0)
            {
                currMana = 0;
            }
        }
    }

    public void ReplenishMana()
    {
        currMana++;
    }
}
