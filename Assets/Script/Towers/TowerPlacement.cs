
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Import Unity's UI namespace

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private GameObject scoreManagerObject; // Reference to ScoreManager GameObject


    public int TowerCost = 30;
    private GameObject CurrentPlacingTower;
    private ScoreUI scoreManager;

    private DataManager dataManager;


    void Start()
    {
        // Get the ScoreManager script component from the scoreManagerObject
        scoreManager = scoreManagerObject.GetComponent<ScoreUI>();
        dataManager = FindObjectOfType<DataManager>();
    }

    void Update()
    {
        if (CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camray, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                // Adjust the tower's position based on hit normal and tower size
                float towerHeight = .01f;
                float yOffset = towerHeight / 2f; // Half tower height

                Vector3 towerPosition = hitInfo.point + hitInfo.normal * towerHeight;
                CurrentPlacingTower.transform.position = towerPosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                // Confirm tower placement when clicking
                CurrentPlacingTower = null;
                dataManager.UpdateTowersPlaced(1);
            }
        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        if (scoreManager.GetCurrentScore() >= TowerCost)
        {
            // Deduct points for building a tower using ScoreManager
            scoreManager.UpdateScore(-TowerCost);

            // Instantiate the tower if enough points are available
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Insufficient points to build the tower!");
            // Handle the case where there are not enough points to build a tower
        }
    }
}
