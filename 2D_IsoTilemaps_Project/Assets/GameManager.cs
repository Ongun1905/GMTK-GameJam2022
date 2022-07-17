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
        playerController.moveAllowed = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(playerController.waypointIndex >
            playerStartWaypoint + diceSideThrown) {
            playerStartWaypoint = playerController.waypointIndex - 1;
            playerController.moveAllowed = false;
       }

        if (playerController.waypointIndex ==
            playerController.waypoints.Length)
        {
            playerStartWaypoint = 0;
        }


    }

    public void MovePlayer()
    {
        playerController.moveAllowed = true;
    }
}
