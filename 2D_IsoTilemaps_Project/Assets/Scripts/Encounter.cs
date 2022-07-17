using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    private EnemyController enemyController;
    private DiceController enemyDiceController;
    private DiceController playerDiceController;
    private PlayerStatsController playerStatsController;

    private bool rolled = false;

    public void InitializeEncounter(GameObject enemy, GameObject enemyDice, GameObject playerDice, GameObject player)
    {
        enemyController = enemy.GetComponent<EnemyController>();
        enemyDiceController = enemyDice.GetComponent<DiceController>();
        enemyDiceController.ResetDiceRolled();
        playerDiceController = playerDice.GetComponent<DiceController>();
        playerDiceController.ResetDiceRolled();
        playerStatsController = player.GetComponent<PlayerStatsController>();

        StartCoroutine(InitiativeRoll());
    }

    private IEnumerator PlayerRoll()
    {
        yield return new WaitUntil(() => playerDiceController.GetDiceRolledSinceLastReset() == true); // Wait unitl the player has rolled
        playerDiceController.ResetDiceRolled(); // We reset the boolean telling us the player rolled to false
        Debug.Log("[Encounter]    Player Rolled");
        rolled = true;
    }

    private IEnumerator EnemyRoll()
    {
        StartCoroutine(enemyDiceController.RollTheDice()); // Roll for the enemy (duhhh)
        yield return new WaitUntil(() => enemyDiceController.GetDiceRolledSinceLastReset() == true); // Wait until the enemy rolled COMPLETELY
        enemyDiceController.ResetDiceRolled(); // Reset the boolean telling us it rolled to false
        Debug.Log("[Encounter]    Enemy rolled");
        rolled = true;
    }

    private IEnumerator InitiativeRoll()
    {
        StartCoroutine(PlayerRoll());
        yield return new WaitUntil(() => rolled == true);
        rolled = false;
        int playerInitiative = GameManager.diceSideThrown; // We store the number thrown by player.

        StartCoroutine(EnemyRoll());
        yield return new WaitUntil(() => rolled == true);
        rolled = false;
        int enemyInitiative = GameManager.diceSideThrown; // We store the number thrown by the enemy.

        if (playerInitiative >= enemyInitiative)
        {
            StartCoroutine(PlayerTurn());
        } else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    private IEnumerator PlayerTurn()
    {
        Debug.Log("[Encounter]    Player's turn starting!");
        StartCoroutine(PlayerRoll());
        yield return new WaitUntil(() => rolled == true);
        rolled = false;

        Debug.Log("[Encounter]    === Player's waituntil finished ===");

        int playerDamage = GameManager.diceSideThrown;
        enemyController.ModifyHealth(-playerDamage);

        if (enemyController.GetHealth() <= 0)
        {
            EncounterController encounterController = gameObject.GetComponent<EncounterController>();
            encounterController.StopEncounter(true);
        } else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    private IEnumerator EnemyTurn()
    {
        Debug.Log("[Encounter]    Enemy's turn starting!");
        StartCoroutine(EnemyRoll());
        yield return new WaitUntil(() => rolled == true);
        rolled = false;

        int enemyDamage = GameManager.diceSideThrown;
        playerStatsController.ModifyHealth(-enemyDamage);

        if (playerStatsController.GetHealth() <= 0)
        {
            EncounterController encounterController = gameObject.GetComponent<EncounterController>();
            encounterController.StopEncounter(false);
        }
        else
        {
            StartCoroutine(PlayerTurn());
        }
    }
}
