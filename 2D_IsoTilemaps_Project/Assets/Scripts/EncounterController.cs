using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemyDice;
    [SerializeField] GameObject playerDice;
    [SerializeField] Vector3 playerEncounterPostion;
    [SerializeField] Vector3 enemyEncounterPosition;

    [SerializeField] GameObject[] enemyPrefabs;

    private GameObject enemy;
    private IsometricCharacterRenderer isoRenderer;
    private IsometricPlayerMovementController playerMovementController;
    private PlayerStatsController playerStatsController;
    private int lastTileIndex;

    private void Start()
    {
        enemyDice.SetActive(false);
        isoRenderer = player.GetComponentInChildren<IsometricCharacterRenderer>();
        playerMovementController = player.GetComponent<IsometricPlayerMovementController>();
        playerStatsController = player.GetComponent<PlayerStatsController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            StartEncounter(playerMovementController.waypointIndex);
        }
    }

    private void SetPlayerToEncounterPosition()
    {
        player.transform.position = playerEncounterPostion;
        isoRenderer.SetStaticDirection(new Vector2(- Mathf.Sqrt(0.5f), Mathf.Sqrt(0.5f)));
    }

    private GameObject SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length - 1);
        GameObject newEnemy = Instantiate(enemyPrefabs[randomIndex], enemyEncounterPosition, Quaternion.identity);
        return newEnemy;
    }

    public void StartEncounter(int indexEncounterTile)
    {
        GameManager.inEncounter = true;
        lastTileIndex = indexEncounterTile;
        enemyDice.SetActive(true);

        SetPlayerToEncounterPosition();
        enemy = SpawnRandomEnemy();

        Encounter newEncounter = gameObject.AddComponent<Encounter>();
        newEncounter.InitializeEncounter(enemy, enemyDice, playerDice, player);
    }

    public void StopEncounter(bool encounterWon)
    {
        // Set encounter meta variables
        GameManager.inEncounter = false;
        enemyDice.SetActive(false);

        if (encounterWon)
        {
            // Teleport the player back to their last position
            player.transform.position = playerMovementController.waypoints[lastTileIndex].transform.position;
            isoRenderer.SetDirection(new Vector2(0f, -0.5f));

            // Increment the player's score
            playerStatsController.IncrementScore(10);

            // Play main track
            GameManager.gm.PlayMainMusic();
            GameManager.inEncounterMusic = false;
        } else
        {
            // Back to main menu (destroy all by swapping scenes)
            Debug.Log("You died lmao");
            SceneManager.LoadScene(0);
        }
    }
}
