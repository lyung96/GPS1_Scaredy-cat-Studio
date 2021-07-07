using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float xaxis;
    public float yaxis;
    public bool isShake;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + xaxis, player.position.y + yaxis, transform.position.z);
        /*if (isShake == false)
        {
            transform.position = new Vector3(player.position.x + xaxis, player.position.y + yaxis, transform.position.z);
        }*/
    }

    /*public IEnumerator CameraShake()
    {
        isShake = true;
        transform.position = new Vector3(player.position.x + xaxis + Random.Range(-1 , 1), player.position.y + yaxis + Random.Range(-1, 1), transform.position.z);
        transform.position = new Vector3(player.position.x + xaxis + Random.Range(-1, 1), player.position.y + yaxis + Random.Range(-1, 1), transform.position.z);
        transform.position = new Vector3(player.position.x + xaxis + Random.Range(-1, 1), player.position.y + yaxis + Random.Range(-1, 1), transform.position.z);
        yield return new WaitForSeconds(1f);
        isShake = false;
    }*/
}
