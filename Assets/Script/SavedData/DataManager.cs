using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private ScoreUI ScoreManager;
    private IconManager iconManager;

    // stats
    private int maxScore = 0;
    private int gamesPlayed = 0;

    // achievements
    public int enemiesKilled { get; private set; } = 0;
    public int towersPlaced { get; private set; } = 0;
    public int balloonsPopped { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = FindObjectOfType<ScoreUI>();
        iconManager = FindAnyObjectByType<IconManager>();

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
        iconManager.CreateEnemyKilledIcon();
    }

    public void UpdateGamesPlayed(int amount)
    {
        gamesPlayed += amount;
        PlayerPrefs.SetInt("gamesPlayed", gamesPlayed);
    }

    public void UpdateTowersPlaced(int amount)
    {
        towersPlaced += amount;
        PlayerPrefs.SetInt("towersPlaced", towersPlaced);
        iconManager.CreateTowerIcon();
    }

    public void ResetTowersPlaced(int num)
    {
        towersPlaced = num;
        PlayerPrefs.SetInt("towersPlaced", 0);
    }

    public void ResetEnemiesKilled(int num)
    {
        enemiesKilled = num;
        PlayerPrefs.SetInt("enemiesKilled", 0);
    }
}
