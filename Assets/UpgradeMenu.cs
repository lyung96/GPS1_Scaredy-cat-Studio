using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private float playerLevel;
    private float expCost;

    private void Update()
    {
        //if(playerLevel == 0)
        //{
        //    expCost = 1;
        //}
        //else if()
        switch(playerLevel)
        {

        }
    }

    public void UpgradeHealth()
    {
        if(PlayerController.exp >= expCost)
        {
            //maxHealthIncrease
            //playelevel increase
            //exoCost increase
        }
    }

    public void UpgradeMana()
    {

    }
}
