using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bselector : MonoBehaviour
{
    public Camera PlayerCamera;
    public LayerMask towerLayerMask;
    public PauseMenu pauseReference;
    public GameOverManager GameManager;
    private TowerBUpgrades upgradeUI;

    void Update()
    {
        Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        if (!pauseReference.isPaused && !GameManager.isGameOver)
        {
            if (Physics.Raycast(camray, out RaycastHit hit, Mathf.Infinity, towerLayerMask))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Input on tower.");
                    GameObject selectedTower = hit.collider.gameObject;
                    if (selectedTower != null)
                    {
                        OpenTowerBUI(selectedTower);
                    }
                }
            }

        }
        else
        {
            Debug.Log(upgradeUI);
            CloseTowerBUI();
        }
    }

    void OpenTowerBUI(GameObject tower)
    {
        upgradeUI = tower.GetComponentInChildren<TowerBUpgrades>();
        if (upgradeUI != null)
        {
            upgradeUI.SetTower(tower);
        }
    }

    void CloseTowerBUI()
    {
        if (upgradeUI != null)
        {
            Debug.Log(upgradeUI);
            upgradeUI.TurnUIoff();
        }
    }



}
