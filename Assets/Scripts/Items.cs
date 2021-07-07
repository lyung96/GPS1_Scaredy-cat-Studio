using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.GetType() == typeof(BoxCollider2D))
        {
            if (trigger.gameObject.CompareTag("Player"))
            {
                Debug.Log("Triggered White Mask");
                ScoreSystem.scoreNum++;
                Destroy(gameObject);
            }
        }
    }
}
