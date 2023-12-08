using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private GameObject scoreManagerObject; // Reference to ScoreManager GameObject

    public int TowerACost = 30;
    public int TowerBCost = 50;
    public int TowerCCost = 30;
    private GameObject CurrentPlacingTower;

    public string towerPlacementPlatformTag = "TowerPlacementPlatform";
    private ScoreUI scoreManager;

    private DataManager dataManager;




    void Start()
    {
        scoreManager = scoreManagerObject.GetComponent<ScoreUI>();
        dataManager = FindObjectOfType<DataManager>();
    }

    void Update()
    {
        if (CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

            //raycast on to ground layer
            if (Physics.Raycast(camray, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                //set
                Vector3 towerPosition = hitInfo.point + hitInfo.normal * .01f;
                CurrentPlacingTower.transform.position = towerPosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray towerRay = new Ray(CurrentPlacingTower.transform.position + Vector3.up, Vector3.down);

                //check if raycast is on tile
                if (Physics.Raycast(towerRay, out hit, Mathf.Infinity, LayerMask.GetMask("Tile")))
                {
                    TowerPlacementPlatform towerPlatform = hit.collider.GetComponent<TowerPlacementPlatform>();
                    if (towerPlatform.HasTower() == false)
                    {
                        // place tower
                        CurrentPlacingTower = null;
                        dataManager.UpdateTowersPlaced(1);
                        towerPlatform.UpdateTowerStatus(true);
                    }
                }


            }
        }
    }

    //function for button setting a tower to place
    public void SetTowerAToPlace(GameObject tower)
    {
        if (scoreManager.GetCurrentScore() >= TowerACost)
        {
            // Deduct points for building a tower using ScoreManager
            scoreManager.UpdateScore(-TowerACost);
            // Instantiate the tower if enough points are available
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Insufficient points to build the tower!");
            // Handle the case where there are not enough points to build a tower
        }
    }

    public void SetTowerBToPlace(GameObject tower)
    {
        if (scoreManager.GetCurrentScore() >= TowerBCost)
        {
            // Deduct points for building a tower using ScoreManager
            scoreManager.UpdateScore(-TowerBCost);
            // Instantiate the tower if enough points are available
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Insufficient points to build the tower!");
            // Handle the case where there are not enough points to build a tower
        }
    }

    public void SetTowerCToPlace(GameObject tower)
    {
        if (scoreManager.GetCurrentScore() >= TowerCCost)
        {
            // Deduct points for building a tower using ScoreManager
            scoreManager.UpdateScore(-TowerCCost);
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