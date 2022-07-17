using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    // Singleton instance:
    public static PlayerCombatController playerCombatControllerInstance;
    
    private PlayerStatsController playerStatsController;

    private void Awake()
    {
        // Checks if there's already an instance of player stats. 
        if (playerCombatControllerInstance == null)
        {
            playerCombatControllerInstance = GetComponent<PlayerCombatController>(); //If not, assign this component to be that instance
        }
        else
        {
            Destroy(GetComponent<PlayerCombatController>()); //Else: destroy this component: we do not want two player stats.
        }
    }

    private void Start()
    {
        playerStatsController = GetComponent<PlayerStatsController>();
    }

    public void ModifyHealth(int change)
    {
        playerStatsController.playerHealth += change;

        if (playerStatsController.playerHealth < 1)
        {
            // end game
        }
    }

    private void AttackEnemy(GameObject enemyObject)
    {
        EnemyController enemyController = enemyObject.GetComponent<EnemyController>();

        enemyController.ModifyHealth(GenerateDamage());
    }

    private int GenerateDamage()
    {
        //return Random.Range(0, maxRandomDamage);
        return 0;
    }
}
