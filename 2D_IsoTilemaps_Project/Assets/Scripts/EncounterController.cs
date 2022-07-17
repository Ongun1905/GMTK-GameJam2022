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
    private int lastTileIndex;

    private void Start()
    {
        enemyDice.SetActive(false);
        isoRenderer = player.GetComponentInChildren<IsometricCharacterRenderer>();

        StartCoroutine(TestStart());
    }

    IEnumerator TestStart ()
    {
        yield return new WaitForSeconds(0.1f);
        StartEncounter(0);

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
        newEncounter.InitializeEncounter(enemy, enemyDice, playerDice);
    }
}
