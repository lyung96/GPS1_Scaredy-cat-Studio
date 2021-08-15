using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class lvl3obj : MonoBehaviour
{
    public TextMeshProUGUI objective;
    // Start is called before the first frame update
    void Start()
    {
        objective.text = "Get into the compound";
    }

    // Update is called once per frame
    public void Update()
    {
        if (level3trigger.trigger)
        {
            objective.text = "Defeat the boss";
        }
    }
}
