
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public Image healthBarImage;

    public Gradient healthGradient;
    public GameObject impactParticlePrefab;
    public AudioClip deathSound;
    public AudioClip deathSound2;
    private ScoreUI ScoreManager;
    private DataManager dataManager;
    
    
    void Start()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;

        ScoreManager = FindObjectOfType<ScoreUI>();
        dataManager = FindObjectOfType<DataManager>();
        healthBarImage = GetComponentInChildren<Image>();
        UpdateHealthBar();
    }
    void Update()
    {
        // Make the health bar face the camera
        if (Camera.main != null)
        {
           healthBarImage.transform.LookAt(Camera.main.transform);
        }
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
        GameObject impactParticles = Instantiate(impactParticlePrefab, transform.position, Quaternion.identity);
        //particles won't stay forever, destroyed after the "duration" on the particle system
        float particleDestroyDelay = impactParticles.GetComponent<ParticleSystem>().main.duration; 
        Destroy(impactParticles, particleDestroyDelay);
        ScoreManager.UpdateScore(10);
        // Destroy the enemy GameObject
        Destroy(gameObject);
        // Notify Data Manager
        dataManager.UpdateEnemyCount(1);
        if (Random.Range(0, 2) == 0)
    {
        // Play the first death sound
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }
    else
    {
        // Play the second death sound
        if (deathSound2 != null)
        {
            AudioSource.PlayClipAtPoint(deathSound2, transform.position);
        }
    }
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