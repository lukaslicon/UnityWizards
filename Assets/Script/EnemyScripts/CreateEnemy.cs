using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro library

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public Transform spawnPoint;
    public Transform parentTransform; // Assign the parent transform in the Inspector
    public float spawnInterval = 2.0f;
    public int maxEnemies = 2;
    public Button roundButton;
    public TextMeshProUGUI roundText; // Reference to the TextMeshPro Text
    private int enemiesSpawned = 0;
    private int currentRound = 0;

    void Start()
    {
        roundButton.onClick.AddListener(StartNextRound);
    }
    void StartNextRound()
    {
        UpdateRoundText();
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
        roundButton.interactable = false;
        
    }

    void SpawnEnemy()
    {
        if (enemiesSpawned < maxEnemies)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            if (parentTransform != null)
            {
                enemy.transform.parent = parentTransform;
            }

            Debug.Log("Enemy Created!");
            enemiesSpawned++;
        }
        else
        {
            Debug.Log("Max enemies reached. Stopping spawning.");
            CancelInvoke("SpawnEnemy");
            roundButton.interactable = true;
            enemiesSpawned = 0;
        }
    }
 
    void UpdateRoundText()
    {
        currentRound++;
        roundText.text = "Round " + currentRound.ToString();
    }
}
