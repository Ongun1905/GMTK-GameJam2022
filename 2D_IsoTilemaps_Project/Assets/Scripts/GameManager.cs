using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = true;

    public static GameObject player;

    public static int diceSideThrown = 0;
    public static int playerStartWaypoint = 0;

    IsometricPlayerMovementController playerController;


    public static GameManager gm;
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<IsometricPlayerMovementController>();
        gm = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(playerController.waypointIndex >
            playerStartWaypoint + diceSideThrown) {
            playerStartWaypoint = playerController.waypointIndex - 1;
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