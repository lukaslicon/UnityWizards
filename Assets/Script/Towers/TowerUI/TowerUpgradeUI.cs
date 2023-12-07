using UnityEngine;
using TMPro;

public class TowerUpgradeUI : MonoBehaviour
{
    public GameObject upgradeMenuUI;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI explosionRadiusText;
    public TextMeshProUGUI explosionDamageText;
    public TextMeshProUGUI attackSpeedAttr;
    public TextMeshProUGUI explosionRadiusAttr;
    public TextMeshProUGUI explosionDamageAttr;
    // public TextMeshProUGUI shootingRangeText;

    private bool isClicked = false;
    private GameObject tower;
    public GameObject component;
    private int attackSpeedLevel = 0;
    private int explosionRadiusLevel = 0;
    private int explosionDamageLevel = 0;
    private int shootingRangeLevel = 0;

    public void SetTower(GameObject towerObject)
    {
        TurnUIon();
        tower = towerObject;
        UpdateUI();
    }

    public void UpgradeAttackSpeed()
    {
        if (component.GetComponent<ShootBullet>().shootingCooldown<= .5)
        {
            Debug.Log("MAX SPEED UPGRADES");
        }
        else
        {
            component.GetComponent<ShootBullet>().shootingCooldown -= .25f;
            attackSpeedLevel += 1;
            UpdateUI();
        }
    }

    public void UpgradeExplosionRadius()
    {
        
        component.GetComponent<ShootBullet>().explosionRadius += 10;
        explosionRadiusLevel += 1;
        UpdateUI();
    }

    public void UpgradeExplosionDamage()
    {
        component.GetComponent<ShootBullet>().explosionDamage += 5;
        explosionDamageLevel += 1;
        UpdateUI();
    }

    public void UpgradeShootingRange()
    {
        component.GetComponent<ShootBullet>().shootingRange += 5;
        shootingRangeLevel += 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        attackSpeedAttr.text = "Attack Cooldown: " + component.GetComponent<ShootBullet>().shootingCooldown;
        attackSpeedText.text = "Level: " + attackSpeedLevel;
        explosionRadiusText.text = "Level: " + explosionRadiusLevel;
        explosionRadiusAttr.text = "Explosion Radius: " + component.GetComponent<ShootBullet>().explosionRadius;
        explosionDamageText.text = "Level: " + explosionDamageLevel;
        explosionDamageAttr.text = "Explosion DMG: " + component.GetComponent<ShootBullet>().explosionDamage;
        // shootingRangeText.text = "Shooting Range: " + shootingRangeLevel;
    }

    private void ToggleUpgradeUI(bool condition)
    {
        upgradeMenuUI.SetActive(condition);
        isClicked = condition;
    }

    private void TurnUIon()
    {
        ToggleUpgradeUI(true);
    }

    public void TurnUIoff()
    {
        ToggleUpgradeUI(false);
    }
}
