using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleTop : MonoBehaviour
{
    public static bool isOnTop = false;
    private GameObject player;
    Grapple grappleScript;

    /*private void Start()
    {
        player = GameObject.Find("Player");
        grappleScript = player.GetComponent<Grapple>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            grappleScript.Detatch();
        }
    }*/
}
