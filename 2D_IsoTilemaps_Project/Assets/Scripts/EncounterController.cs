using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 playerEncounterPostion;
    [SerializeField] Vector3 enemyEncounterPosition;

    [SerializeField] GameObject[] enemyPrefabs;
    
    private IsometricCharacterRenderer isoRenderer;
    private int lastTileIndex;

    private void Start()
    {
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

    private void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length - 1);
        GameObject newEnemy = Instantiate(enemyPrefabs[randomIndex], enemyEncounterPosition, Quaternion.identity);
    }

    public void StartEncounter(int indexEncounterTile)
    {
        lastTileIndex = indexEncounterTile;

        SetPlayerToEncounterPosition();
        SpawnRandomEnemy();
    }
}
