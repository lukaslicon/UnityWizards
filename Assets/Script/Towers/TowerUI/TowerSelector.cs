using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public Camera PlayerCamera;
    public LayerMask towerLayerMask;
    public PauseMenu pauseReference;
    public GameOverManager GameManager;
    private TowerUpgradeUI upgradeUI;

    void Update()
    {
        Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        if (!pauseReference.isPaused && !GameManager.isGameOver)
        {
            if (Physics.Raycast(camray, out RaycastHit hit, Mathf.Infinity, towerLayerMask))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    GameObject selectedTower = hit.collider.gameObject;
                    if (selectedTower != null)
                    {
                        OpenTowerCUI(selectedTower);
                    }
                }
            }

        }
        else
        {
            CloseTowerCUI();
        }
    }

    void OpenTowerCUI(GameObject tower)
    {
        upgradeUI = tower.GetComponentInChildren<TowerUpgradeUI>();
        if (upgradeUI != null)
        {
            upgradeUI.SetTower(tower);
        }
    }

    void CloseTowerCUI()
    {
        if (upgradeUI != null)
        {
            Debug.Log(upgradeUI);
            upgradeUI.TurnUIoff();
        }
    }



}
