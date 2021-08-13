using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lvl1obj : MonoBehaviour
{
    public TextMeshProUGUI objective;
    // Start is called before the first frame update
    void Start()
    {
        objective.text = "Get a key to enter the building";
    }

    // Update is called once per frame
    public void Update()
    {
        if (LockMessage.dooropen==true)
        {
            Debug.Log("isopen: " + LockMessage.dooropen);
            objective.text = "Find the invader of the clan";
        }
    }
}
