using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField]
    private Collider2D box;
    [SerializeField]
    private Collider2D circle;
    [SerializeField]
    private Collider2D edge;


    private void Awake()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), box, true);
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), circle.GetComponent<CircleCollider2D>(), true);
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), edge.GetComponent<EdgeCollider2D>() , true);

    }

}
