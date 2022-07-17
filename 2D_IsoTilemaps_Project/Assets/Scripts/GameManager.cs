using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = true;
    public static bool inEncounter = false;

    public static GameObject player;

    public static int diceSideThrown = 0;
    public static int playerStartWaypoint = 0;

    public AudioClip menuMusic;
    public AudioClip mainMusic;
    public AudioClip encounterClip;
    private AudioSource audioSource;

    IsometricPlayerMovementController playerController;

    SoundHandler sh;

    public static GameManager gm;
    // Start is called before the first frame update
    


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sh = GetComponent<SoundHandler>();
        gm = GetComponent<GameManager>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayMenuMusic();
        } 


        if (SceneManager.GetActiveScene().buildIndex == 1 )
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<IsometricPlayerMovementController>();
            PlayMainMusic();
        }


    }

    // Update is called once per frame
    void Update()
    {
       if(playerController != null)
        {
            if (playerController.waypointIndex >
            playerStartWaypoint + diceSideThrown)
            {
                playerStartWaypoint = playerController.waypointIndex - 1;
            }


            if (playerController.waypointIndex == 9 || playerController.waypointIndex == 25)
            {
                if(inEncounter == false) {
                    PlayEncounterMusic();
                    inEncounter = true;
                }
                
                Debug.Log("call encounter function");

            }

        }

    }

    public void PlayMenuMusic()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.PlayOneShot(menuMusic);
    }

    public void PlayMainMusic()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.PlayOneShot(mainMusic);
    }

    public void PlayEncounterMusic()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.PlayOneShot(encounterClip);
    }

    public IEnumerator MovePlayer()
    {
        for (int i = 0; i < diceSideThrown; i++)
        {
            playerController.Move();
            yield return new WaitForSeconds(0.5f);
        }
    }

}
