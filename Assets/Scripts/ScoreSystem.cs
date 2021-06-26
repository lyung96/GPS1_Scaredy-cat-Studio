using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreSystem : MonoBehaviour
{
    public Text scoring;
    public static int scoreNum = 0;

    private void Start()
    {
        scoreNum = 0;
    }

    void Update()
    {
        scoring.text = "Exp: " + scoreNum;
    }
}
