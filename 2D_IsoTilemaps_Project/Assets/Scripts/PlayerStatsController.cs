using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsController : MonoBehaviour
{
    public int playerMaxHealth = 20;
    public int playerHealth;
    public int playerScore = 0;

    public HealthBarController healthBar;
    public TextMeshProUGUI sText;

    void Start()
    {
        // Set up player health
        playerHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            ModifyHealth(-1);
        }

        if (Input.GetKeyDown("s"))
        {
            IncrementScore(1);
        }
    }

    public void ModifyHealth(int health)
    {
        playerHealth += health;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
        healthBar.SetHealth(playerHealth);
    }

    public int GetHealth()
    {
        return playerHealth;
    }

    public void IncrementScore(int score)
    {
        playerScore += score;
        sText.text = $"{playerScore:00000}";
    }
}
