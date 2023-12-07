using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public Camera PlayerCamera;
    public LayerMask towerLayerMask;

    void Update()
    {
        Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camray, out RaycastHit hit, Mathf.Infinity, towerLayerMask))
        {
            GameObject selectedTower = hit.collider.gameObject;
            if (Input.GetMouseButtonDown(1))
            {
                if (selectedTower != null)
                {
                    OpenTowerUI(selectedTower);
                }
            }
        }
       
    }

    void OpenTowerUI(GameObject tower)
    {
        TowerUpgradeUI upgradeUI = tower.GetComponentInChildren<TowerUpgradeUI>();
        if (upgradeUI != null)
        {
            upgradeUI.SetTower(tower);
        }
    }
}
