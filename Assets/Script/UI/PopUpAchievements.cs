using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PopUpAchievements : MonoBehaviour
{
    public Image towerPlacedIcon;

    public GameObject UIParticles;

    private AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopUpIcon(Image icon)
    {
        if (icon != null)
        {
            icon.transform.SetParent(transform);
            RectTransform rt = icon.GetComponent<RectTransform>();
            rt.localPosition = Vector3.zero;
            rt.localScale = Vector3.one;

            // animate icon pop up
            audioSource.PlayOneShot(audioClip, 0.5f);
            rt.DOLocalMoveY(300, 1f).SetEase(Ease.OutBounce);

            GameObject particles = Instantiate(UIParticles, rt);
            particles.transform.localPosition = Vector3.zero;
            ParticleSystem particlesSystem = particles.GetComponentInChildren<ParticleSystem>();

            // change color of particles according to icon
            var particlesMain = particlesSystem.main;
            particlesMain.startColor = icon.color;

            particlesSystem.Play();
            particlesSystem.Emit(20);

            Debug.Log("ICON : " + icon + " ");
        }
    }

    public IEnumerator DestroyIcon(Image icon, TMP_Text text)
    {
        yield return new WaitForSeconds(3);
        RectTransform rt = icon.GetComponent<RectTransform>();
        rt.DOLocalMoveY(700, 0.7f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(1);
        Destroy(icon);
        Destroy(text);
    }
}
