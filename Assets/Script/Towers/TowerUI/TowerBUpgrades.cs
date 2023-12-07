using UnityEngine;
using TMPro;

public class TowerBUpgrades : MonoBehaviour
{
    public GameObject upgradeMenuUI;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI attackSpeedAttr;

    //public TextMeshProUGUI explosionRadiusText;

    public TextMeshProUGUI explosionDamageText;
    public TextMeshProUGUI explosionDamageAttr;

    public TextMeshProUGUI shootingRangeText;
    public TextMeshProUGUI shootingRangeAttr;

    public TextMeshProUGUI attackSpeedCostText; // Text for attack speed upgrade cost
    public TextMeshProUGUI explosionDamageCostText; // Text for explosion damage upgrade cost
    public TextMeshProUGUI shootingRangeCostText; // Text for shooting range upgrade cost

    private bool isClicked = false;
    private GameObject tower;
    public GameObject component;

    private int attackSpeedLevel = 0;
    private int explosionRadiusLevel = 0;
    private int explosionDamageLevel = 0;
    private int shootingRangeLevel = 0;

    private int attackSpeedUpgradeCost = 10;
    private int explosionRadiusCost = 10;
    private int explosionDamageCost = 10;
    private int shootingRangeCost = 10;

    private ScoreUI scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreUI>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
            // Handle the case where the ScoreManager is not found
        }
   }
        public void SetTower(GameObject towerObject)
    {
        TurnUIon();
        tower = towerObject;
        UpdateUI();
    }

    public void UpgradeAttackSpeed()
    {
        int upgradeCost = attackSpeedUpgradeCost * (attackSpeedLevel + 1);
        if (scoreManager.GetCurrentScore() >= upgradeCost)
        {
            if (component.GetComponent<ShootBullet>().shootingCooldown <= 0.5f)
            {
                Debug.Log("MAX SPEED UPGRADES");
            }
            else
            {
                component.GetComponent<ShootBullet>().shootingCooldown -= 0.25f;
                attackSpeedLevel += 1;
                scoreManager.UpdateScore(-upgradeCost);
                UpdateAttackSpeedCostText();
                UpdateUI();
            }
        }
        else
        {
            Debug.Log("Insufficient points to upgrade attack speed!");
            // Handle case where there are not enough points for the upgrade
        }
    }

    public void UpgradeExplosionDamage()
    {
        int upgradeCost = explosionDamageCost * (explosionDamageLevel + 1);
        if (scoreManager.GetCurrentScore() >= upgradeCost)
        {
            component.GetComponent<ShootBullet>().explosionDamage += 1;
            explosionDamageLevel += 1;
            scoreManager.UpdateScore(-upgradeCost);
            UpdateExplosionDamageCostText();
            UpdateUI();
        }
        else
        {
            Debug.Log("Insufficient points to upgrade explosion damage!");
            // Handle case where there are not enough points for the upgrade
        }
    }

    public void UpgradeShootingRange()
    {
        int upgradeCost = shootingRangeCost * (shootingRangeLevel + 1);
        if (scoreManager.GetCurrentScore() >= upgradeCost)
        {
            component.GetComponent<ShootBullet>().shootingRange += 2;
            shootingRangeLevel += 1;
            scoreManager.UpdateScore(-upgradeCost);
            UpdateShootingRangeCostText();
            UpdateUI();
        }
        else
        {
            Debug.Log("Insufficient points to upgrade shooting range!");
            // Handle case where there are not enough points for the upgrade
        }
    }


    private void UpdateAttackSpeedCostText()
    {
        if (attackSpeedCostText != null)
        {
            int currentUpgradeCost = attackSpeedUpgradeCost * (attackSpeedLevel + 1);
            attackSpeedCostText.text = "Cost\n" + currentUpgradeCost;
        }
        else
        {
            Debug.LogWarning("AttackSpeedCostText not assigned!");
            // Handle the case where AttackSpeedCostText is not assigned
        }
    }
    private void UpdateExplosionDamageCostText()
    {
        if (explosionDamageCostText != null)
        {
            int currentUpgradeCost = explosionDamageCost * (explosionDamageLevel + 1);
            explosionDamageCostText.text = "Cost\n" + currentUpgradeCost;
        }
        else
        {
            Debug.LogWarning("ExplosionDamageCostText not assigned!");
            // Handle the case where ExplosionDamageCostText is not assigned
        }
    }

    private void UpdateShootingRangeCostText()
    {
        if (shootingRangeCostText != null)
        {
            int currentUpgradeCost = shootingRangeCost * (shootingRangeLevel + 1);
            shootingRangeCostText.text = "Cost\n" + currentUpgradeCost;
        }
        else
        {
            Debug.LogWarning("ShootingRangeCostText not assigned!");
            // Handle the case where ShootingRangeCostText is not assigned
        }
    }
    private void UpdateUI()
    {
        attackSpeedText.text = "Level: " + attackSpeedLevel;
        attackSpeedAttr.text = "Attack Cooldown: " + component.GetComponent<ShootBullet>().shootingCooldown;
        explosionDamageText.text = "Level: " + explosionDamageLevel;
        explosionDamageAttr.text = "Explosion DMG: " + component.GetComponent<ShootBullet>().explosionDamage;
        shootingRangeText.text = "level: " + shootingRangeLevel;
        shootingRangeAttr.text = "Range: " + component.GetComponent<ShootBullet>().shootingRange;
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
