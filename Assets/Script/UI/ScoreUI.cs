using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 100;

    private void Start()
    {
        score = 100;
        UpdateScoreText();
    }
    public int GetCurrentScore()
    {
        return score;
    }
    public void UpdateScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Points: " + score.ToString();
        }
    }
}
