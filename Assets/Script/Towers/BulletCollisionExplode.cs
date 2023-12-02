using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionExplode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject impactParticlePrefab;
    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate impact particle system
        Instantiate(impactParticlePrefab, transform.position, Quaternion.identity);

        // Apply damage or other logic based on the collision
        // For example, you might check the tag of the collided object and apply damage to an enemy

        // Destroy the bullet
        Destroy(gameObject);
    }
}
