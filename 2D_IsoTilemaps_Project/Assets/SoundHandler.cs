using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] audioSources;

    private AudioSource backgroundMusic;
    private AudioSource mainMenuMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();

        backgroundMusic = audioSources[0];
        mainMenuMusic = audioSources[1];
    }

    public void playBackgroundMusic()
    {
        backgroundMusic.Play();
    }

    public void playMenuMusic()
    {
        mainMenuMusic.Play();
    }

    public void stopMenuMusic()
    {
        mainMenuMusic.Stop();
    }

}
