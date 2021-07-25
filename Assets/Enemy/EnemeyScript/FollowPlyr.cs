using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlyr : MonoBehaviour
{
    public Transform Target;
    public float MinModifier;
    public float MaxModifier;

    Vector3 _Velocity = Vector3.zero;
    bool _IsFollowing = false;

    void Start()
    {
        
    }

    public void StartFollowing()
    {
        _IsFollowing = true;
    }

    void Update()
    {
        if (_IsFollowing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Target.position - new Vector3(-1,-1), ref _Velocity, Time.deltaTime * Random.Range(MinModifier, MaxModifier));
            //need to use vector3 cuz dunno why this target.position cant reach the target. 
        }
    }
}
