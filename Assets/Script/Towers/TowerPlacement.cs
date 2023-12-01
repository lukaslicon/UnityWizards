using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    private GameObject CurrentPlacingTower;

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
            }
        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
}
