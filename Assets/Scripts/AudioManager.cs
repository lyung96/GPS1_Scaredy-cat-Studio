using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;
    public Sound[] sounds;
    public static AudioManager instance;

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
        }
        PlayMusic();
    }

    public void PlayMusic()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name == "Menu")
        {
            StopPlaying("LevelMusic");
            Play("Theme");
        }
        else if (name == "GameLevel1")
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

    //public void ChangeVolume(string name)
    //{
    //    Sound s = Array.Find(sounds, sound => sound.name == name);
    //    if (s == null)
    //    {
    //        Debug.LogWarning("Sound: " + name + "not found!");
    //        return;
    //    }
    //    FindObjectOfType<AudioManager>().SetVolume(name,slider.value(name, SetVolume));
    //    slider.value=SetVolume(name)
    //}

}
