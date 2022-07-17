using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    private EnemyController enemyController;
    private DiceController enemyDiceController;
    private DiceController playerDiceController;

    public void InitializeEncounter(GameObject enemy, GameObject enemyDice, GameObject playerDice)
    {
        enemyController = enemy.GetComponent<EnemyController>();
        enemyDiceController = enemyDice.GetComponent<DiceController>();
        enemyDiceController.ResetDiceRolled();
        playerDiceController = playerDice.GetComponent<DiceController>();
        playerDiceController.ResetDiceRolled();

        InitiativeRoll();
    }

    private void Start()
    {
        
    }

    private IEnumerator PlayerRoll()
    {
        yield return new WaitUntil(() => playerDiceController.GetDiceRolledSinceLastReset() == true); // Wait unitl the player has rolled
        playerDiceController.ResetDiceRolled(); // We reset the boolean telling us the player rolled to false
        Debug.Log("Player Rolled");
    }

    private IEnumerator EnemyRoll()
    {
        StartCoroutine(enemyDiceController.RollTheDice()); // Roll for the enemy (duhhh)
        yield return new WaitUntil(() => enemyDiceController.GetDiceRolledSinceLastReset() == true); // Wait until the enemy rolled COMPLETELY
        enemyDiceController.ResetDiceRolled(); // Reset the boolean telling us it rolled to false
        Debug.Log("Enemy rolled");
    }

    private void InitiativeRoll()
    {
        StartCoroutine(PlayerRoll());
        int playerInitiative = GameManager.diceSideThrown; // We store the number thrown by player.

        StartCoroutine(EnemyRoll());
        int enemyInitiative = GameManager.diceSideThrown; // We store the number thrown by the enemy.

        if (playerInitiative >= enemyInitiative)
        {
            PlayerTurn();
        } else
        {
            PlayerTurn();
        }
    }

    private void PlayerTurn()
    {
        PlayerRoll();
        int playerDamage = GameManager.diceSideThrown;
        enemyController.ModifyHealth(-playerDamage);

        EnemyTurn();
    }

    private void EnemyTurn()
    {
        EnemyRoll();
    }
}
