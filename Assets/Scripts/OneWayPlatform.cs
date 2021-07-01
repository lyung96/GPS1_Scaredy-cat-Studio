using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private bool isFalling = false;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            isFalling = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                effector.rotationalOffset = 180f;
                isFalling = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isFalling == false))
        {
            effector.rotationalOffset = 0;
        }
    }
}
