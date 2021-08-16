using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    public GameObject respawnPanel;
    public Checkpoint checkpoint;
    public static RespawnMenu instance;
    private string lastScene;
    private string currScene;
    public bool panelActive = false;
    public static bool nextLvl;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);  
    }

    // Start is called before the first frame update
    void Start()
    {
        respawnPanel.SetActive(false);
        lastScene = SceneManager.GetActiveScene().name;
        UpdateRef();
    }

    // Update is called once per frame
    void Update()
    {
        changeScene();
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine("Respawn");
        }

        if (Boss.killmc==false)
        {
            if (playerController != null)
            {
                if ((playerController.currHealth <= 0) && (panelActive == false))
                {
                    respawnPanel.SetActive(true);
                    panelActive = true;
                }
                else if (playerController.currHealth > 0)
                {
                    panelActive = false;
                }
            }
            else if (SceneManager.GetActiveScene().name != "Menu")
            {
                UpdateRef();
            }
        }
        
    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene("Menu");
        respawnPanel.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().StopPlaying("LevelMusic");
    }

    public void setrespawnactive()
    {
        respawnPanel.SetActive(true);
    }
    public void RespawnButton()
    {
        if (SceneManager.GetActiveScene().name == "GameLevel1" && nextLvl == true)
        {
            FindObjectOfType<UpgradeMenu>().NextLevelButton();
            nextLvl = false;
            StartCoroutine("Respawn");
            respawnPanel.SetActive(false);
        }
        else
        {
            StartCoroutine("Respawn");
            respawnPanel.SetActive(false);
            DialogBegining.dialogcounter += 1;
        }
    }

    public IEnumerator Respawn()
    {
        Animator animator = player.GetComponent<Animator>();
        animator.SetTrigger("respawn");
        PlayerController.isDead = false;
        yield return new WaitForSeconds(0.1f); 
        UpdateRef();
        checkpoint.LoadandUpdate();
    }

    public void changeScene()
    {
        currScene = SceneManager.GetActiveScene().name;
        if (currScene != lastScene)
        {
            if (currScene != "Menu")
            {
                UpdateRef();
                Debug.Log("ChangeScene");
            }
            lastScene = currScene;
        }
    }

    public void UpdateRef()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        checkpoint = FindObjectOfType<Checkpoint>();
        respawnPanel = gameObject.transform.GetChild(0).gameObject;
    }
}
