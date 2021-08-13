using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorDoor : MonoBehaviour
{
    public GameObject eIconPromt;
    private GameObject parentDoor;
    public Sprite openedDoor;
    private bool isOpen;


    private void Start()
    {
        isOpen = false;
        eIconPromt.SetActive(false);
        parentDoor = gameObject.transform.parent.gameObject;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(isOpen == false)
            {
                eIconPromt.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                SpriteRenderer door = parentDoor.GetComponent<SpriteRenderer>();
                door.sprite = openedDoor;
                parentDoor.GetComponent<BoxCollider2D>().enabled = false;
                eIconPromt.SetActive(false);
                isOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        eIconPromt.SetActive(false);
    }
}
