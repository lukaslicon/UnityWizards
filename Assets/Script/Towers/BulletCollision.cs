using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollision : MonoBehaviour
{
    public int damagePerShot = 15;
    private ScoreUI ScoreManager;
    
    private void Start()
    {
        // Find the GameManager in the scene
        ScoreManager = FindObjectOfType<ScoreUI>();

        if (ScoreManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.CompareTag("enemy"))
        {
            enemyHealth.TakeDamage(damagePerShot);
            if (ScoreManager != null)
            {
                //ScoreManager.UpdateScore(10);
                Debug.Log("Player Gained Score");
            }
            else
            {
                Debug.LogError("GameManager not assigned.");
            }
        }
    }

    
}
