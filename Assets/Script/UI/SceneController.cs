using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneToLoad;

    private void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Successfully loaded scene.");
    }
}
