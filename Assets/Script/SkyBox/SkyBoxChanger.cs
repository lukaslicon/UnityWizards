using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material[] skyboxes;
    public float switchSkyBox = 30.0f;

    private float timer;
    private int currentSkyboxIndex;

    void Start()
    {
        if (skyboxes.Length == 0)
        {
            Debug.LogError("No skybox");
            return;
        }

        RenderSettings.skybox = skyboxes[0];
        currentSkyboxIndex = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchSkyBox)
        {
            timer = 0;
            currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
            RenderSettings.skybox = skyboxes[currentSkyboxIndex];
            DynamicGI.UpdateEnvironment();
        }
    }
}
