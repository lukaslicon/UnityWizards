using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CollisionDestroy: MonoBehaviour
{
    public GameOverManager GameManager;
    public Image healthBarImage;
    public TextMeshProUGUI healthText;
    public float health = 100;
    public float maxHealth = 100;
    private void Start()
    {
        UpdateHealthText();
    }
    public void UpdateHealth(float amount)
    {
        health -= amount;
        UpdateHealthText();
    }
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            UpdateHealth(10);
            Debug.Log("Player Lost health");
            UpdateHealthBar();
            if (health <= 0)
            {
                GameManager.isGameOver = true;
                Debug.Log("Game Lost");
            }
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage == null)
        {
            Debug.LogWarning("Health bar image or player reference is not set.");
            return;
        }
        float healthPercentage = health / maxHealth;
        healthBarImage.fillAmount = healthPercentage;
        healthBarImage.transform.parent.transform.DOShakePosition(0.5f, 20);
    }

}
