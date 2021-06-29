using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Impact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

}
