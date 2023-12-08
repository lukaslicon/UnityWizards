using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private TowerUpgradeUI upgradeUI;
    public GameObject pauseMenuUI;

    public Button TowerA;
    public Button TowerB;
    public Button TowerC;

    public Button resumeButton; 
    public Button mainMenuButton;
    public Button restartButton; 

    public bool isPaused = false;

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
        TowerA.gameObject.SetActive(!pause);
        TowerB.gameObject.SetActive(!pause);
        TowerC.gameObject.SetActive(!pause);
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
    }
}
