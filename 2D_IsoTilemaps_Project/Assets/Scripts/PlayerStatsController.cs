using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public int playerMaxHealth = 10;
    public int playerHealth;
    public int playerScore = 0;

    public HealthBarController healthBar;

    void Start()
    {
        playerHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown("s"))
        {
            IncrementScore(1);
        }
    }

    void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            Debug.Log("Player health is 0, queue game end!");
        }
        healthBar.SetHealth(playerHealth);
    }

    void IncrementScore(int score)
    {
        playerScore += score;
    }
}
