using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] audioSources;

    private AudioSource backgroundMusic;
    private AudioSource mainMenuMusic;
    private AudioSource encounterMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();

        backgroundMusic = audioSources[0];
        mainMenuMusic = audioSources[1];
        encounterMusic = audioSources[2];
    }

   public void changeBGM(int index, int newIndex)
    {
        audioSources[index].Stop();
        audioSources[newIndex].Play();

    }
}
