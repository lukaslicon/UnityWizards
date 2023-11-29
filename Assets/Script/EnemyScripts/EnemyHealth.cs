
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public Image healthBarImage;

    public Gradient healthGradient;
    private ScoreUI ScoreManager;
    
    void Start()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;

        ScoreManager = FindObjectOfType<ScoreUI>();
        UpdateHealthBar();
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
        UpdateHealthBar();
    }

    // Optional: Method to handle enemy death behavior
    void Die()
    {
        // You can add behavior here, such as triggering an animation or particle effect
        ScoreManager.UpdateScore(10);
        // Destroy the enemy GameObject
        Destroy(gameObject);
    }

    
    void UpdateHealthBar()
    {
        // Calculate the fill amount based on the current health
        float fillAmount = (float)currentHealth / maxHealth;

        // Set the fill amount of the health bar image
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = fillAmount;
            healthBarImage.color = healthGradient.Evaluate(1 - fillAmount);
        }
    }
}