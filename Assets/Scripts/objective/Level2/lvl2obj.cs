using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lvl2obj : MonoBehaviour
{
    public TextMeshProUGUI objective;
    // Start is called before the first frame update
    void Start()
    {
        objective.text = "Get the power up";
    }

    // Update is called once per frame
    public void Update()
    {
        if (chestopener1.obtainedkey)
        {
            objective.text = "Meet up with the mysterious voice";
        }
    }
}
