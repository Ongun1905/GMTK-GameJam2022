using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxRandomDamage;
    [SerializeField] int baseDamage;


    private int GenerateDamage()
    {
        return baseDamage + Random.Range(0, maxRandomDamage);
    }

    public void AttackPlayer()
    {
        PlayerCombatController.playerCombatControllerInstance.ModifyHealth(GenerateDamage());
    }

    public void ModifyHealth(int change)
    {
        health += change;

        if (health < 1)
        {
            KillEnemy();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
