using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainTimer : MonoBehaviour
{
    public ParticleSystem rainPS;
    public float minTimeUntilRain = 5.0f;
    public float maxTimeUntilRain = 20.0f;
    public float rainDuration = 10.0f;

    private float timer;
    private bool isRaining;

    void Start()
    {
        if (rainPS == null)
        {
            Debug.LogError("No Rain assign!");
            return;
        }

        // Start with no rain
        rainPS.Stop();
        isRaining = false;
        ResetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (isRaining)
            {
                // Stop raining and reset timer
                rainPS.Stop();
                isRaining = false;
                ResetTimer();
            }
            else
            {
                // Start raining
                rainPS.Play();
                isRaining = true;
                timer = rainDuration;
            }
        }
    }

    private void ResetTimer()
    {
        timer = Random.Range(minTimeUntilRain, maxTimeUntilRain);
    }
}
