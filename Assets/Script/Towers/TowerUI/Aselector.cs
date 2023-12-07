using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aselector : MonoBehaviour
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
                    OpenTowerAUI(selectedTower);
                }
            }
        }

    }

    void OpenTowerAUI(GameObject tower)
    {
        TowerAUpgrades upgradeUI = tower.GetComponentInChildren<TowerAUpgrades>();
        if (upgradeUI != null)
        {
            upgradeUI.SetTower(tower);
        }
    }

}
