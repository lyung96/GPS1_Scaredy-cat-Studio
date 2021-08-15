using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIgnoresPlayer : MonoBehaviour
{
    [SerializeField]
    private Collider2D box;
    [SerializeField]
    private CircleCollider2D circle;
    [SerializeField]
    private EdgeCollider2D edge;

    public ActivateWhenContact activate;

    private void IgnoreMe()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), box, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), circle, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), edge, true);

    }

    void Update()
    {
        if (activate.ActivatedBoss == true)
        {
            IgnoreMe();
            activate.enabled = false;
        }
    }
}
