using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMask : MonoBehaviour
{
    public Sprite emptyMask;
    public Sprite oneMask;
    public Sprite twoMask;
    public Sprite FullMask;

    public Image[] masks;

    public GameObject mask1;
    public  bool mask1active = false;

    public GameObject mask2;
    public bool mask2active = false;

    public GameObject mask3;
    public bool mask3active = false;

    // Start is called before the first frame update
    void Start()
    {
        Activatemask1();
    }

    // Update is called once per frame
    void Update()
    {
        //if 1 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Activatemask1();//set mask1 active, mask2 and mask 3 inactive
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))//if 2 is pressed
        {
            Activatemask2();//set mask2 active, mask1 and mask 3 inactive
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))//if 3 is pressed
        {
            Activatemask3();//set mask3 active, mask1 and mask 2 inactive
        }
    }
    public void Activatemask1()
    {
        mask1.SetActive(true);
        Debug.Log("Mask 1 Activated");
        mask1active = true;
        mask2.SetActive(false);
        mask3.SetActive(false);
        mask2active = false;
        mask3active = false;
    }

    public void Activatemask2()
    {
        mask2.SetActive(true);
        Debug.Log("Mask 2 Activated");
        mask2active = true;
        mask1.SetActive(false);
        mask3.SetActive(false);
        mask1active = false;
        mask3active = false;
    }
    
    public void Activatemask3()
    {
        mask3.SetActive(true);
        Debug.Log("Mask 3 Activated");
        mask3active = true;
        mask2.SetActive(false);
        mask1.SetActive(false);
        mask1active = false;
        mask2active = false;
    }
}
