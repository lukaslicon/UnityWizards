using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneToLoad;

    private DataManager dataManager;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Successfully loaded scene.");
        dataManager.UpdateGamesPlayed(1);
    }
}
