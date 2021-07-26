using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public static LevelChanger instance;
    private int levelToLoad;
    private string lastScene;
    private string currScene;

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
        lastScene = SceneManager.GetActiveScene().name;
    }

        // Update is called once per frame
        void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            FadeToNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            FadeToPreviousLevel();
        }
        changeScene();
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToPreviousLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");
    }

    public void changeScene()
    {
        currScene = SceneManager.GetActiveScene().name;
        if (lastScene != currScene)
        {
            if (currScene != "Menu")
            {
                GameObject player = GameObject.Find("Player");

                player.GetComponent<PlayerController>().curseBar.SetMaxHealth(player.GetComponent<PlayerController>().maxCurseBar, player.GetComponent<PlayerController>().maxCurseBar);
                player.GetComponent<PlayerController>().curseBar.SetHealth(player.GetComponent<PlayerController>().maxCurseBar);
                player.GetComponent<PlayerController>().manaController.numOfMana = player.GetComponent<PlayerController>().maxMana;
                player.GetComponent<PlayerController>().manaController.maxMana = player.GetComponent<PlayerController>().maxMana;
            }
            //OnFadeComplete();
            lastScene = currScene;
        }
    }
}
