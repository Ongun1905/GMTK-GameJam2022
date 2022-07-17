using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemyDice;
    [SerializeField] GameObject playerDice;
    [SerializeField] Vector3 playerEncounterPostion;
    [SerializeField] Vector3 enemyEncounterPosition;

    [SerializeField] GameObject[] enemyPrefabs;

    private IsometricCharacterRenderer isoRenderer;
    private IsometricPlayerMovementController playerMovementController;
    private int lastTileIndex;

    private void Start()
    {
        enemyDice.SetActive(false);
        isoRenderer = player.GetComponentInChildren<IsometricCharacterRenderer>();
        playerMovementController = player.GetComponent<IsometricPlayerMovementController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            StartEncounter(0);
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
        GameObject enemy = SpawnRandomEnemy();

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
            // Destroy enemy gameobject

            // Teleport the player back to their last position
            player.transform.position = playerMovementController.waypoints[lastTileIndex].transform.position;
            isoRenderer.SetDirection(new Vector2(-Mathf.Sqrt(0.5f), Mathf.Sqrt(0.5f)));
        } else
        {
            // Back to main menu (destroy all)

        }
    }
}
