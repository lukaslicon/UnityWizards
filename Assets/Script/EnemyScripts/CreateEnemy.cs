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
        int remainingEnemies = maxEnemies - enemiesSpawned;
        int spawnCount = Mathf.Min(remainingEnemies, spawnPointsEnemies.Length - currentSpawnPointIndex);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject enemy = Instantiate(spawnPointsEnemies[currentSpawnPointIndex].enemyPrefab, spawnPointsEnemies[currentSpawnPointIndex].spawnPoint.position, spawnPointsEnemies[currentSpawnPointIndex].spawnPoint.rotation);

            if (parentTransform != null)
            {
                enemy.transform.parent = parentTransform;
            }

            Debug.Log("Enemy Created at Spawn Point " + (currentSpawnPointIndex + 1));
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPointsEnemies.Length; // Move to the next spawn point
        }

        enemiesSpawned += spawnCount;

        if (enemiesSpawned >= maxEnemies)
        {
            Debug.Log("Max enemies reached. Stopping spawning.");
            CancelInvoke("SpawnEnemy");
            roundButton.interactable = true;
        }
    }


    void UpdateRoundText()
    {
        currentRound++;
        roundText.text = "Round " + currentRound.ToString();
        maxEnemies *= 2; // Double the max enemies for the next round (exponential growth)
    }
}
