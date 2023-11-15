using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CollisionDestroy: MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int health = 100;
    private void Start()
    {
        UpdateHealthText();
    }
    public void UpdateHealth(int amount)
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

            if (health <= 0)
            {
                Debug.Log("Game Lost");
            }
        }
    }

}
