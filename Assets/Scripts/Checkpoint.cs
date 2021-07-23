using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;
    private string lastScene;
    private string currScene;
    public int saveCounter;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        saveCounter = 0;
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {//For dev testing only
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadandUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (saveCounter < 1)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                saveCounter++;
                SaveSystem.SavePlayer(playerController);
                playerController.currHealth = playerController.maxCurseBar;
                playerController.curseBar.SetHealth(playerController.maxCurseBar);
                playerController.curseBar.SetMaxHealth(playerController.maxCurseBar, playerController.maxCurseBar);
                playerController.manaController.currMana = playerController.manaController.maxMana;
                playerController.shurikenController.shuriken = playerController.shurikenController.maxShuriken;                
            }
        }
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerController.maxCurseBar = data.maxHp;
        playerController.maxMana = data.maxMp;
        playerController.maskCollected = data.maskPieces;
        PlayerController.exp = data.exp;
        PlayerController.playerLevel = data.playerLevel;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

    }

    public void LoadandUpdate()
    {
        LoadPlayer();
        playerController.Load();
    }

    public void changeScene()
    {
        currScene = SceneManager.GetActiveScene().name;
        if (lastScene != currScene)
        {
            saveCounter = 0;           
            lastScene = currScene;
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerController);
        playerController.currHealth = playerController.maxCurseBar;
        playerController.curseBar.SetHealth(playerController.maxCurseBar);
        playerController.curseBar.SetMaxHealth(playerController.maxCurseBar, playerController.maxCurseBar);
        playerController.manaController.currMana = playerController.manaController.maxMana;
        playerController.shurikenController.shuriken = playerController.shurikenController.maxShuriken;
    }
}
