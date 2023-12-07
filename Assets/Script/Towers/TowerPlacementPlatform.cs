using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementPlatform : MonoBehaviour
{
    private bool hasTower = false;

    public bool HasTower()
    {
        return hasTower;
    }

    public void UpdateTowerStatus(bool status)
    {
        hasTower = status;
    }
}
