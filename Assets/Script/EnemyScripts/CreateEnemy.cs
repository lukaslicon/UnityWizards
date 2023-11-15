using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public Transform spawnPoint;
    public Transform parentTransform; // Assign the parent transform in the Inspector
    public float spawnInterval = 2.0f;
    public int maxEnemies = 10;

    private int enemiesSpawned = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
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
        }
    }
}
