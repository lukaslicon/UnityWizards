
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    private ScoreUI ScoreManager;
    void Start()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;

        ScoreManager = FindObjectOfType<ScoreUI>();
    }

    // Method to decrease enemy health
    public void TakeDamage(int damage)
    {
        // Decrease health by the damage amount
        currentHealth -= damage;

        // Check if the enemy is defeated
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Optional: Method to handle enemy death behavior
    void Die()
    {
        // You can add behavior here, such as triggering an animation or particle effect
        ScoreManager.UpdateScore(10);
        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}