using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aselector : MonoBehaviour
{
    public Camera PlayerCamera;
    public LayerMask towerLayerMask;
    public PauseMenu pauseReference;
    public GameOverManager GameManager;
    private TowerAUpgrades upgradeUI;

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
                        OpenTowerAUI(selectedTower);
                    }
                }
            }

        }
        else
        {
            Debug.Log(upgradeUI);
            CloseTowerAUI();
        }
    }

    void OpenTowerAUI(GameObject tower)
    {
        upgradeUI = tower.GetComponentInChildren<TowerAUpgrades>();
        if (upgradeUI != null)
        {
            upgradeUI.SetTower(tower);
        }
    }

    void CloseTowerAUI()
    {
        if (upgradeUI != null)
        {
            Debug.Log(upgradeUI);
            upgradeUI.TurnUIoff();
        }
    }



}
