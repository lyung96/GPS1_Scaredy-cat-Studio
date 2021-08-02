using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePopUpInstructions: MonoBehaviour
{
    public GameObject MovementInstructions;
    public GameObject Collider;
    public GameObject DashInstructions;
    public GameObject JumpInstructions;
   
    
    public static bool left = false;
    public static bool right = false;
    public static bool dash = false;
    public static bool jump = false;
    public static bool grap = false;
    public static bool entertutorialarea = false, triggertutorial=false;
    
    // Start is called before the first frame update
    void Start()
    {
        MovementInstructions.SetActive(false);
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggertutorial = true;
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entertutorialarea = false;
            triggertutorial = false;
        }
    }

   
    private void MovePopoff()
    {
        MovementInstructions.SetActive(false);
    }
    private void DashPopoff()
    {
        DashInstructions.SetActive(false);
    }

    private void DashPopup()
    {
        DashInstructions.SetActive(true);
    }

    private void JumpPopup()
    {
        JumpInstructions.SetActive(true);
    }

    private void JumpPopoff()
    {
        JumpInstructions.SetActive(false);
    }




    private void Update()
    {
        if (triggertutorial)//enter
        {
            if (grap==false && left==false && right==false && jump==false && dash==false)
            {
                Debug.Log("triggertutorial");
                MovementInstructions.SetActive(true);
            }
            if (left && right)
            {
                MovementInstructions.SetActive(false);
                if (dash)
                {
                    DashInstructions.SetActive(false);
                    if (jump)
                    {
                        JumpInstructions.SetActive(false);

                    }
                }
            }
        }

        if (entertutorialarea)//stay
        {
            if (grap == false)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    left = true;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    right = true;
                }
                if (left && right && jump==false && dash==false)
                {
                    Invoke("MovePopoff", 0.5f);
                    Invoke("DashPopup", 0.5f);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        dash = true;
                    }
                    if (dash && jump ==false)
                    {
                        Debug.Log("Dash Fullfilled");
                        Invoke("DashPopoff", 0.5f);
                        Invoke("JumpPopup", 0.5f);
                        if (Input.GetKey(KeyCode.Space))
                        {
                            jump = true;
                        }
                        if (jump && dash == false && left == false && right == false)
                        {
                            Invoke("JumpPopoff", 0.5f);
                            
                        }
                    }
                }
            }
                
        }

        if (entertutorialarea == false && triggertutorial == false)//exit
        {
            MovementInstructions.SetActive(false);

            DashInstructions.SetActive(false);

            JumpInstructions.SetActive(false);
            if (left && right && dash && jump)
            {
                Destroy(Collider);
                
                MovementInstructions.SetActive(false);

                DashInstructions.SetActive(false);

                JumpInstructions.SetActive(false);

            }

        }
    }
       
}


