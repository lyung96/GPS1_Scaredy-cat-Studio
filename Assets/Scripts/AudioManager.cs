using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public Slider bgSlider;
    public float bgVolume;
    public Slider sfxSlider;
    public float sfxVolume;
    public Sound[] sounds;
    public static AudioManager instance;
    private string lastScene;
    private string currScene;
    private GameObject optionMenu;
    public bool startVol;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        lastScene = SceneManager.GetActiveScene().name;
        optionMenu = GameObject.Find("Options Menu");   
        bgSlider = optionMenu.GetComponent<OptionMenu>().oBgSlider;
        sfxSlider = optionMenu.GetComponent<OptionMenu>().oSfxSlider;
        PlayMusic();
    }

    private void Start()
    {
        startVol = true;
    }

    private void Update()
    {
        changeScene();
        UpdateVolume();
        SetSfx();
        SetBGMusic();
    }

    public void PlayMusic()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name == "Menu")
        {
            StopPlaying("LevelMusic");
            StopPlaying("FinalBoss");
            StopPlaying("EndScene");
            Play("Theme");
        }
        else if (name == "GameLevel1" || name == "GameLevel1 (CAT)" || name == "GameLevel1 (LZJ)" || name == "GameLevel1 (Yung)" || name == "GameLevel2" || name == "GameLevel3" || name == "GameLevel4")
        {
            StopPlaying("Theme");
            StopPlaying("FinalBoss");
            StopPlaying("EndScene");
            Play("LevelMusic");
        }
        else if (name == "GameLevel5")
        {
            StopPlaying("Theme");
            StopPlaying("LevelMusic");
            StopPlaying("EndScene");
            Play("FinalBoss");
        }
        else if(name == "GameLevel6")
        {
            StopPlaying("Theme");
            StopPlaying("LevelMusic");
            StopPlaying("FinalBoss");
            Play("EndScene"); 
        }
    }
        
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Stop();
    }

    public float SetVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return 0;
        }
        s.source.volume = volume;
        return volume;

        
    }

    public void SetPitch(string name, float setPitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.pitch = setPitch;
    }

    public void SetBGMusic()
    {
        SetVolume("LevelMusic", bgVolume);
        SetVolume("Theme", bgVolume);
        SetVolume("FinalBoss", bgVolume);
        SetVolume("Boss", bgVolume);
    }

    public void SetSfx()
    {
        SetVolume("Fireball", sfxVolume);
        SetVolume("PlayerRun", sfxVolume);
        SetVolume("Slash", sfxVolume);
        SetVolume("Hit", sfxVolume);
        SetVolume("Blood", sfxVolume);
    }
    public void UpdateVolume()
    {
        
        bgVolume = bgSlider.value;
        sfxVolume = sfxSlider.value;
        if(startVol == true)
        {
            bgSlider.value = 0.5f;
            sfxSlider.value = 0.5f;
            OptionsMusic.slider.value = 0.5f;
            startVol = false;
        }
    }

    /*public void setSlider()
     {
         if (currScene == "Menu")
         {
             Slider currS = FindObjectsOfTypeAll(typeof(UnityEngine.UI.Slider)) as 
             currSfxSlider = mainSfxSlider;
         }
         else if (currScene == "Gamelevel1")
         {
             currBgSlider = inGameBgSlider;
             currSfxSlider = inGameSfxSlider;
         }
     }*/

    /*public void updateVolume()
    {
        if (currScene == "Menu")
        {
            currBgSlider.value = mainBgSlider.value;
            currSfxSlider.value = mainSfxSlider.value;
        }
        else if (currScene == "Gamelevel1")
        {
            currBgSlider.value = inGameBgSlider.value;
            currSfxSlider.value = inGameSfxSlider.value;
        }

        bgVolume = currBgSlider.value;
        sfxVolume = currSfxSlider.value;
    }*/


    public void changeScene()
    {
        currScene = SceneManager.GetActiveScene().name;
        if (lastScene != currScene)
        {
            //if (currScene != "Menu")
            //{
                optionMenu = GameObject.Find("Options Menu");
                bgSlider = optionMenu.GetComponent<OptionMenu>().oBgSlider;
                sfxSlider = optionMenu.GetComponent<OptionMenu>().oSfxSlider;
                PlayMusic();
            //}
            lastScene = currScene;
        } 
    }
}
