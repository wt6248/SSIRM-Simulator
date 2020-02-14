using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource source;
    public AudioClip backgroundMusic;           //Inspector 에서 지정, 현재 : SSirm King (Cyber)
    
    void Start()
    {
        source = GetComponent<AudioSource>();
        //StartBGM();
    }

    public void StartBGM()
    {
        source.clip = backgroundMusic;
        source.loop = false;
        source.volume = 0.3f;
        source.Play();
    }
    
    void Update()
    {
        
    }
}
