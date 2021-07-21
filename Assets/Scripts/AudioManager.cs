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

    private void Update()
    {
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
            Play("Theme");
        }
        else if (name == "GameLevel1" || name == "GameLevel1 (CAT)" || name == "GameLevel1 (LZJ)" || name == "GameLevel1 (Yung)")
        {
            StopPlaying("Theme");
            Play("LevelMusic");
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
        //SetVolume("FinalBossMusic", bgVolume);
        //SetVolume("BossMusic", bgVolume);
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
            bgSlider = optionMenu.GetComponent<OptionMenu>().oBgSlider;
            sfxSlider = optionMenu.GetComponent<OptionMenu>().oSfxSlider;
            lastScene = currScene;
        } 
    }
}
