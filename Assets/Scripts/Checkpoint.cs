using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayer();//problem
            playerController.Load();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SaveSystem.SavePlayer(playerController);
            playerController.currCurse = 0;
            playerController.curseBar.SetHealth(0);
            playerController.manaController.currMana = playerController.manaController.maxMana;
            playerController.shurikenController.shuriken = playerController.shurikenController.maxShuriken;
        }
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();//problem

        playerController.maxCurse = data.maxHp;
        playerController.maxMana = data.maxMp;
        playerController.maskCollected = data.maskPieces;
        playerController.Exp = data.Exp;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

    }
}
