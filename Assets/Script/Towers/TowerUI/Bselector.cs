using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bselector : MonoBehaviour
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
                Debug.Log("Input on tower.");
                if (selectedTower != null)
                {
                    OpenTowerBUI(selectedTower);
                }
            }
        }

    }


    void OpenTowerBUI(GameObject tower)
    {
        TowerBUpgrades upgradeUI = tower.GetComponentInChildren<TowerBUpgrades>();
        if (upgradeUI != null)
        {
            upgradeUI.SetTower(tower);
        }
    }

}
