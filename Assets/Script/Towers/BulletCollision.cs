using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollision : MonoBehaviour
{
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
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            if (ScoreManager != null)
            {
                ScoreManager.UpdateScore(10);
                Debug.Log("Player Gained Score");
            }
            else
            {
                Debug.LogError("GameManager not assigned.");
            }
        }
    }
}
