using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro library

[System.Serializable]
public class SpawnPointEnemy // Class to associate spawn points with enemy prefabs
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;
}

public class CreateEnemy : MonoBehaviour
{
    public SpawnPointEnemy[] spawnPointsEnemies; // Array of SpawnPointEnemy to associate spawn points with enemy prefabs
    public Transform parentTransform; // Assign the parent transform in the Inspector
    public float spawnInterval = 2.0f;
    public int maxEnemies = 2;
    public Button roundButton;
    public TextMeshProUGUI roundText; // Reference to the TextMeshPro Text
    private int enemiesSpawned = 0;
    private int currentRound = 0;
    private int currentSpawnPointIndex = 0; // Index to track the current spawn point

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
        if (currentSpawnPointIndex < spawnPointsEnemies.Length)
        {
            GameObject enemy = Instantiate(spawnPointsEnemies[currentSpawnPointIndex].enemyPrefab, spawnPointsEnemies[currentSpawnPointIndex].spawnPoint.position, spawnPointsEnemies[currentSpawnPointIndex].spawnPoint.rotation);

            if (parentTransform != null)
            {
                enemy.transform.parent = parentTransform;
            }

            Debug.Log("Enemy Created at Spawn Point " + (currentSpawnPointIndex + 1));
            enemiesSpawned++;
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPointsEnemies.Length; // Move to the next spawn point
        }
        else
        {
            Debug.LogError("Invalid spawn point index: " + currentSpawnPointIndex);
        }
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
