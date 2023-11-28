using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    public string sceneToLoad; 

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Successfully loaded scene.");
    }
}
