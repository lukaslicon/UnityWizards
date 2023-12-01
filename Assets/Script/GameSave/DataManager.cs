using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private ScoreUI ScoreManager;

    // stats
    private int maxScore = 0;
    private int gamesPlayed = 0;

    // achievements
    private int enemiesKilled = 0;
    private int towersPlaced = 0;
    private int balloonsPopped = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = FindObjectOfType<ScoreUI>();

        if (ScoreManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        LoadPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.score > maxScore)
        {
            maxScore = ScoreManager.score;
            PlayerPrefs.SetInt("maxScore", maxScore);
        }
    }

    void LoadPrefs()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        gamesPlayed = PlayerPrefs.GetInt("gamesPlayed", 0);
        enemiesKilled = PlayerPrefs.GetInt("enemiesKilled", 0);
        towersPlaced = PlayerPrefs.GetInt("towersPlaced", 0);
        balloonsPopped = PlayerPrefs.GetInt("balloonsPopped", 0);
    }

    public void UpdateEnemyCount(int amount)
    {
        enemiesKilled += amount;
        PlayerPrefs.SetInt("enemiesKilled", enemiesKilled);
    }
}
