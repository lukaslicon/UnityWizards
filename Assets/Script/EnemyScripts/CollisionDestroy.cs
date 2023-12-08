using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class CollisionDestroy: MonoBehaviour
{
    public GameOverManager GameManager;
    public Image healthBarImage;
    public TextMeshProUGUI healthText;
    public float health = 100;
    public float maxHealth = 100;

    public PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;
    private ChromaticAberration chromaticAberration;

    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        UpdateHealthText();
        if (postProcessVolume.profile.TryGetSettings(out colorGrading))
        {
            UpdateSaturation(health);
        }
        if (postProcessVolume.profile.TryGetSettings(out chromaticAberration))
        {
            UpdateChromaticAberration(health);
        }

        audioSource = GetComponent<AudioSource>();
    }
    
    public void UpdateHealth(float amount)
    {
        health -= amount;
        UpdateHealthText();
        UpdateHealthBar();
        UpdateSaturation(health);
        UpdateChromaticAberration(health);
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
        audioSource.PlayOneShot(audioClip, 0.5f);
        healthBarImage.transform.parent.transform.DOShakePosition(0.5f, 20);
    }

    private void UpdateSaturation(float health)
    {
        if (colorGrading != null)
        {
            float saturationValue = Mathf.Lerp(-100, 0, health / maxHealth);
            colorGrading.saturation.value = saturationValue;
        }
    }
    private void UpdateChromaticAberration(float health)
    {
        if (chromaticAberration != null)
        {
            float aberrationIntensity = Mathf.Lerp(0, 1, 1 - (health / maxHealth));
            chromaticAberration.intensity.value = aberrationIntensity;
        }
    }

}
