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

    IsometricPlayerMovementController playerController;

    SoundHandler sh;

    public static GameManager gm;
    // Start is called before the first frame update
    public void Start()
    {
        
        
        gm = GetComponent<GameManager>();
        sh = GetComponent<SoundHandler>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            sh.playMenuMusic();
        } else
        {
            sh.stopMenuMusic();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 )
        {
            sh.playBackgroundMusic();
            player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<IsometricPlayerMovementController>();
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

        }



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
