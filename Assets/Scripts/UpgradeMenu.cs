using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject UpgradeMenuUI;
    public GameObject playerLevelText;
    public GameObject totalExpText;
    public GameObject costText;
    public GameObject playerHealth;
    public GameObject playerMana;
    private float expCost;
    private GameObject player;
    [HideInInspector]
    public static bool uiActive;
    public LevelChanger levelChanger;

    public static UpgradeMenu instance_UpgradeMenu;
    private void Awake()
    {
        if (instance_UpgradeMenu == null)
        {
            instance_UpgradeMenu = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        UpgradeMenuUI.SetActive(false);
        uiActive = false;
        player = GameObject.Find("Player");
        levelChanger = FindObjectOfType<LevelChanger>().GetComponent<LevelChanger>();
    }

    private void Update()
    {
        switch(PlayerController.playerLevel)
        {
            case 1:
                {
                    expCost = 1;
                    break;
                }
            case 2:
                {
                    expCost = 5;
                    break;
                }
            case 3:
                {
                    expCost = 8;
                    break;
                }
            case 4:
                {
                    expCost = 11;
                    break;
                }
            case 5:
                {
                    expCost = 13;
                    break;
                }
            case 6:
                {
                    expCost = 15;
                    break;
                }
            case 7:
                {
                    expCost = 18;
                    break;
                }
            case 8:
                {
                    expCost = 18;
                    break;
                }
            case 9:
                {
                    expCost = 20;
                    break;
                }
            case 10:
                {
                    expCost = 21;
                    break;
                }
            default:
                {
                    Debug.Log("Level out of bound");
                    PlayerController.playerLevel = 10;
                    break;
                }
        }
        UpdateComponent();
        if (player != null)
        {
            totalExpText.GetComponent<TMPro.TextMeshProUGUI>().text = "Experience : " + PlayerController.exp;
            costText.GetComponent<TMPro.TextMeshProUGUI>().text = "Upgrade cost : " + expCost;
            playerLevelText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player level :" + PlayerController.playerLevel;
            playerHealth.GetComponent<TMPro.TextMeshProUGUI>().text = "Player Health : " + player.GetComponent<PlayerController>().maxCurseBar;
            playerMana.GetComponent<TMPro.TextMeshProUGUI>().text = "Player Mana : " + player.GetComponent<PlayerController>().maxMana;
        }

        if(UpgradeMenuUI.activeInHierarchy)
        {
            uiActive = true;
        }
        else
        {
            uiActive = false;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerController.exp += 10;
        }
    }

    public void UpgradeHealth()
    {
        player = GameObject.Find("Player");
        if (PlayerController.exp >= expCost)
        {
            PlayerController.exp -= expCost;
            PlayerController.playerLevel++;
            player.GetComponent<PlayerController>().maxCurseBar += 1;
            player.GetComponent<PlayerController>().currHealth = player.GetComponent<PlayerController>().maxCurseBar;
            player.GetComponent<PlayerController>().curseBar.SetMaxHealth(player.GetComponent<PlayerController>().maxCurseBar, player.GetComponent<PlayerController>().currHealth);
            player.GetComponent<PlayerController>().curseBar.SetHealth(player.GetComponent<PlayerController>().currHealth);
        }
        else
        {
            Debug.Log("Not enough Exp");
        }
    }

    public void UpgradeMana()
    {
        player = GameObject.Find("Player");
        if (PlayerController.exp >= expCost)
        {
            PlayerController.exp -= expCost;
            PlayerController.playerLevel++;
            player.GetComponent<PlayerController>().maxMana += 1;
            player.GetComponent<PlayerController>().manaController.numOfMana += 1;
            player.GetComponent<PlayerController>().manaController.maxMana += 1;

        }
        else
        {
            Debug.Log("Not enough Exp");
        }
    }
    
    public void NextLevelButton()
    {
        StartCoroutine("NextLevel");
        UpgradeMenuUI.SetActive(false);
    }

    public IEnumerator NextLevel()
    {
        FindObjectOfType<Checkpoint>().Invoke("SavePlayer",0f);
        Debug.Log("Next Level Save");
        levelChanger.FadeToNextLevel();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(1.5f);
        UpdateComponent();
        FindObjectOfType<Checkpoint>().Invoke("LoadandUpdate", 0f);
        Debug.Log("Next Level Load");
        yield return new WaitForSeconds(0.1f);
        if (SceneManager.GetActiveScene().name == "GameLevel1")
        {
            player.transform.position = new Vector3(-29.1f, -1.43f, 0);
        }
        else if (SceneManager.GetActiveScene().name == "GameLevel2")
        {
            player.transform.position = new Vector3(-43.57f, -15.53f, 0);
        }
        else if (SceneManager.GetActiveScene().name == "GameLevel3")
        {
            player.transform.position = new Vector3(-44.31f, -14.59f, 0);
        }
        else if (SceneManager.GetActiveScene().name == "GameLevel4")
        {
            player.transform.position = new Vector3(-43.57f, -14.09f, 0);
        }
        else if (SceneManager.GetActiveScene().name == "GameLevel5")
        {
            player.transform.position = new Vector3(-43.57f, -13.02f, 0);
        }
        else if (SceneManager.GetActiveScene().name == "GameLevel6")
        {
            player.transform.position = new Vector3(5.1f, -16.26f, 0);
        }
    }


    public void UpdateComponent()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    public void Setupgradepaneltrue()
    {
        UpgradeMenuUI.SetActive(true);
    }
}
