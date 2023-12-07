using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionExplode : MonoBehaviour
{
    public GameObject impactParticlePrefab;
    public int numberOfParticles = 5; // Number of particles to instantiate

    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate multiple impact particle systems
        for (int i = 0; i < numberOfParticles; i++)
        {
            Instantiate(impactParticlePrefab, transform.position + Random.insideUnitSphere * 0.5f, Quaternion.identity);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
