using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePopup : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        spriteRenderer.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            spriteRenderer.enabled = false;
    }
}
