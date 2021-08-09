using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lr;

    public LayerMask grappleMask; //What you can grapple to, later change it to tileset layer
    public float moveSpeed = 10;
    public float grappleLenght = 10;
    //public bool isGrappling = false;

    public int maxPoints = 1;

    private Rigidbody2D rig;
    private List<Vector2> points = new List<Vector2>();

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        lr.positionCount = 0;
    }

    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(1) && (PauseMenu.GamePause == false))
    //    {
    //        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    //        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
    //        //Vector2 direction = (mousePos - new Vector2(transform.position.x, transform.position.y - 5)).normalized;


    //        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, grappleLenght, grappleMask);
    //        //RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 5), direction, grappleLenght, grappleMask);
    //        if (hit.collider != null)
    //        {
    //            Vector2 hitPoint = hit.point;
    //            points.Add(hitPoint);

    //            if(points.Count > maxPoints)
    //            {
    //                points.RemoveAt(0);
    //            }
    //        }
    //    }    

    //    if(points.Count > 0)
    //    {
    //        Vector2 moveTo = Centroid(points.ToArray());

    //        rig.MovePosition(Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * moveSpeed));

    //        lr.positionCount = 0;
    //        lr.positionCount = points.Count * 2;
    //        for(int n=0, j=0; n<points.Count*2; n+=2, j++)
    //        {
    //            lr.SetPosition(n, transform.position);
    //            lr.SetPosition(n + 1, points[j]);
    //        }
    //    }

    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Detatch();
    //    }
    //}

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1) && (PauseMenu.GamePause == false))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            //Vector2 direction = (mousePos - new Vector2(transform.position.x, transform.position.y - 5)).normalized;


            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, grappleLenght, grappleMask);
            //RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 5), direction, grappleLenght, grappleMask);
            if (hit.collider != null)
            {
                Vector2 hitPoint = hit.point;
                points.Add(hitPoint);

                if (points.Count > maxPoints)
                {
                    points.RemoveAt(0);
                }
            }
        }

        if (points.Count > 0)
        {
            Vector2 moveTo = Centroid(points.ToArray());

            rig.MovePosition(Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * moveSpeed));

            lr.positionCount = 0;
            lr.positionCount = points.Count * 2;
            for (int n = 0, j = 0; n < points.Count * 2; n += 2, j++)
            {
                lr.SetPosition(n, transform.position);
                lr.SetPosition(n + 1, points[j]);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Detatch();
        }
    }



    public void Detatch()
    {
        lr.positionCount = 0;
        points.Clear();
    }

    //Calculate the center, might not need
    Vector2 Centroid(Vector2[] points)
    {
        Vector2 center = Vector2.zero;
        foreach(Vector2 point in points)
        {
            center += point;
        }
        center /= points.Length;
        return center;
    }
}
