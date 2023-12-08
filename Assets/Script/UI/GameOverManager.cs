using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TowerUpgradeUI upgradeUI;
    public GameObject gameMenuUI;

    public Button TowerA;
    public Button TowerB;
    public Button TowerC;


    public Button mainMenuButton;
    public Button restartButton;

    public bool isGameOver = false;

    private DataManager dataManager;

    void Start()
    {
        //hides pause menu
        ToggleGameOver(false);

        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);

        dataManager = FindObjectOfType<DataManager>();
    }

    void Update()
    {
            if (isGameOver)
            {
                GameOver();
            }
    }

    void ToggleGameOver(bool pause)
    {
        gameMenuUI.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
        TowerA.gameObject.SetActive(!pause);
        TowerB.gameObject.SetActive(!pause);
        TowerC.gameObject.SetActive(!pause);
    }

    void GameOver()
    {
        Debug.Log("Game is over.");
        ToggleGameOver(true);
        dataManager.UpdateGamesPlayed(1);
    }


    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Ocean");
    }
}
