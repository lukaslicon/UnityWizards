using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private ScoreUI ScoreManager;

    private int maxScore = 0;


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

    void SavePrefs()
    {

    }

    void LoadPrefs()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        Debug.Log("MAXSCORE:" + maxScore);
    }
}
