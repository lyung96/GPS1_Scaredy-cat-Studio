using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class OptionsMusic : MonoBehaviour
{
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeVolume(float level)
    {
        mixer.SetFloat("Volume", level);
    }
}
