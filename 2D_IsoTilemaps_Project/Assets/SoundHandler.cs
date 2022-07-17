using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] audioSources;

    private AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();

        backgroundMusic = audioSources[0];
    }

    public void playBackground()
    {
        backgroundMusic.Play();
    }
    
}
