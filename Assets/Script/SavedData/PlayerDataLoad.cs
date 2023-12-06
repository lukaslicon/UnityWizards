using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataLoad : MonoBehaviour
{
    public static PlayerDataLoad main { get; private set; }

    // stats
    public int maxScore = 0;
    public int gamesPlayed = 0;

    // achievements
    public int enemiesKilled { get; private set; } = 0;
    public int towersPlaced { get; private set; } = 0;
    public int balloonsPopped { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (main != null && main != this)
        {
            Destroy(this);
        } else
        {
            main = this;
        }

        LoadPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPrefs()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        gamesPlayed = PlayerPrefs.GetInt("gamesPlayed", 0);
        enemiesKilled = PlayerPrefs.GetInt("enemiesKilled", 0);
        towersPlaced = PlayerPrefs.GetInt("towersPlaced", 0);
        balloonsPopped = PlayerPrefs.GetInt("balloonsPopped", 0);
    }
}
