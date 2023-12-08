using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private GameObject scoreManagerObject; // Reference to ScoreManager GameObject
    [SerializeField] private ParticleSystem placementEffect; // Reference to the particle system

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

            if (Physics.Raycast(camray, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                Vector3 towerPosition = hitInfo.point + hitInfo.normal * .01f;
                CurrentPlacingTower.transform.position = towerPosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray towerRay = new Ray(CurrentPlacingTower.transform.position + Vector3.up, Vector3.down);

                if (Physics.Raycast(towerRay, out hit, Mathf.Infinity, LayerMask.GetMask("Tile")))
                {
                    TowerPlacementPlatform towerPlatform = hit.collider.GetComponent<TowerPlacementPlatform>();
                    if (towerPlatform.HasTower() == false)
                    {
                        // Place tower
                        CurrentPlacingTower = null;
                        dataManager.UpdateTowersPlaced(1);
                        towerPlatform.UpdateTowerStatus(true);

                        // Trigger the particle effect at the tower's position
                        if (placementEffect != null)
                        {
                            ParticleSystem instantiatedEffect = Instantiate(placementEffect, hitInfo.point, Quaternion.identity);
                            instantiatedEffect.Play();
                            Destroy(instantiatedEffect.gameObject, instantiatedEffect.main.duration);
                        }
                    }
                }
            }
        }
    }

    // Functions for setting a tower to place
    public void SetTowerAToPlace(GameObject tower)
    {
        if (scoreManager.GetCurrentScore() >= TowerACost)
        {
            scoreManager.UpdateScore(-TowerACost);
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Insufficient points to build the tower!");
        }
    }

    public void SetTowerBToPlace(GameObject tower)
    {
        if (scoreManager.GetCurrentScore() >= TowerBCost)
        {
            scoreManager.UpdateScore(-TowerBCost);
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Insufficient points to build the tower!");
        }
    }

    public void SetTowerCToPlace(GameObject tower)
    {
        if (scoreManager.GetCurrentScore() >= TowerCCost)
        {
            scoreManager.UpdateScore(-TowerCCost);
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Insufficient points to build the tower!");
        }
    }
}
