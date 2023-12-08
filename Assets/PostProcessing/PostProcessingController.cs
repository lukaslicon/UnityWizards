using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume volume;
    private ColorGrading colorGrading;

    private float currentHue = 0f;
    private float hueChangeRate = 0.1f;
    public float hueAcceleration = 0.005f;

    void Start()
    {
        if (volume == null)
        {
            Debug.LogError("PostProcessVolume not assigned.");
            return;
        }

        volume.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        if (colorGrading != null)
        {
            colorGrading.hueShift.value = currentHue;

            if (currentHue >= 180 || currentHue <= -180)
            {
                hueChangeRate = -hueChangeRate;
            }

            currentHue += hueChangeRate;
            hueChangeRate += (hueChangeRate > 0 ? 1 : -1) * hueAcceleration * Time.deltaTime;
        }
    }
}
