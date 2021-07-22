using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreSystem : MonoBehaviour
{
    public Text scoring;
    public static float scoreNum = 0;
    //PlayerController playerController;
    public GameObject player;

    private void Start()
    {
        //playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        scoreNum = PlayerController.exp;
        scoring.text = "Exp: " + scoreNum;
    }
}
