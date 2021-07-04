using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float xaxis;
    public float yaxis;


    private void Update()
    {
        transform.position = new Vector3(player.position.x + xaxis, player.position.y + yaxis, transform.position.z);
    }
}
