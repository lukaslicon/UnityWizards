using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    public Button resumeButton; 
    public Button mainMenuButton;
    public Button restartButton; 

    private bool isPaused = false;

    private DataManager dataManager;

    void Start()
    {
        //hides pause menu
        TogglePauseMenu(false);

        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        restartButton.onClick.AddListener(RestartGame);

        dataManager = FindObjectOfType<DataManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void TogglePauseMenu(bool pause)
    {
        pauseMenuUI.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
        isPaused = pause;
    }

    void PauseGame()
    {
        TogglePauseMenu(true);
    }

    void ResumeGame()
    {
        TogglePauseMenu(false);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Ocean");
        dataManager.UpdateGamesPlayed(1);
    }
}
