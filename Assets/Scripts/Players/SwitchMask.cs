using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMask : MonoBehaviour
{
    //private PlayerController MaskEffect;

    public GameObject mask1;
    public static bool mask1active = false;

    public GameObject mask2;
    public static bool mask2active = false;

    public GameObject mask3;
    public static bool mask3active = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activatemask1();
            //deaactivatemask2();
            //deaactivatemask3();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //activatemask2();
            deaactivatemask1();
            //deaactivatemask3();
        }
        //    else if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        activatemask3();
        //        deaactivatemask1();
        //        deaactivatemask2();
        //    }
        //}
    }

    public void activatemask1()
    {
        mask1.SetActive(true);
        Debug.Log("Mask 1 Activated");
        mask1active = true;
        mask2.SetActive(false);
        mask3.SetActive(false);
        mask2active = false;
        mask3active = false;
    }
    public void deaactivatemask1()
    {
        mask1.SetActive(false);
        Debug.Log("Mask 1 deActivated");
        mask1active = false;
        if (mask2active == true)
        {
            mask3active = false;
        }
        else if (mask3active == true)
        {
            mask2active = false;
        }
    }

    //    public void activatemask2()
    //    {
    //        mask1.SetActive(true);
    //        Debug.Log("Mask 2 Activated");
    //        mask2active = true;
    //        mask1active = false;
    //        mask3active = false;
    //    }
    //    public void deaactivatemask2()
    //    {
    //        mask1.SetActive(false);
    //        Debug.Log("Mask 2 deActivated");
    //        mask2active = false;
    //        if (mask1active == true)
    //        {
    //            mask3active = false;
    //        }
    //        else if (mask3active == true)
    //        {
    //            mask1active = false;
    //        }
    //    }

    //    public void activatemask3()
    //    {
    //        mask1.SetActive(true);
    //        Debug.Log("Mask 3 Activated");
    //        mask3active = true;
    //        mask1active = false;
    //        mask2active = false;
    //    }
    //    public void deaactivatemask3()
    //    {
    //        mask1.SetActive(false);
    //        Debug.Log("Mask 3 deActivated");
    //        mask3active = false;
    //        if (mask2active == true)
    //        {
    //            mask1active = false;
    //        }
    //        else if (mask1active == true)
    //        {
    //            mask2active = false;
    //        }
    //    }
    //}
}
