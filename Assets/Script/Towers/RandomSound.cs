using UnityEngine;

public class RandomSoundVariation : MonoBehaviour
{
    public AudioClip[] soundVariations;
    public float pitchVariation = 0.1f;
    public float volumeVariation = 0.1f;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayRandomSound()
    {
        if (soundVariations.Length > 0)
        {
            // Select a random sound variation
            AudioClip randomSound = soundVariations[Random.Range(0, soundVariations.Length)];

            // Apply pitch variation
            float randomPitch = Random.Range(1 - pitchVariation, 1 + pitchVariation);

            // Apply volume variation
            float randomVolume = Random.Range(1 - volumeVariation, 1 + volumeVariation);

            // Set audio source properties
            audioSource.clip = randomSound;
            audioSource.pitch = randomPitch;
            audioSource.volume = randomVolume;

            // Play the sound
            audioSource.Play();
        }
    }
}