using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
    public GameObject cubePrefab;
    public float shootingRange = 10f;
    public float shootingCooldown = 1f;
    public float bulletDestroyDelay = 5.0f;

    public AudioClip shootSound;
    private float lastShootTime;
    [SerializeField] public float explosionRadius = 30f;
    [SerializeField] public int explosionDamage = 10;

    void Update()
    {
        if (Time.time - lastShootTime > shootingCooldown)
        {
            // Check for enemies within the shooting range
            Collider[] colliders = Physics.OverlapSphere(transform.position, shootingRange);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("enemy"))
                {
                    // Shoot at the enemy
                    ShootCube(collider.transform.position);
                    lastShootTime = Time.time;
                    break; // Only shoot at one enemy per cooldown
                }
            }
        }
    }

    void ShootCube(Vector3 targetPosition)
    {
        // Instantiate a cube prefab and shoot it towards the enemy
        GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        Rigidbody cubeRb = cube.GetComponent<Rigidbody>();
        if (cubeRb != null)
        {
            // Calculate the direction towards the enemy
            Vector3 shootDirection = (targetPosition - transform.position).normalized;
            // Apply force to shoot the cube
            cubeRb.AddForce(shootDirection * 10f, ForceMode.Impulse);

        }
        // Play the shooting sound
            if (shootSound != null)
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }
        cube.AddComponent<CubeCollisionHandler>();
    }
}


public class CubeCollisionHandler : MonoBehaviour
{
    public float explosionRadius = 30f;
    public int explosionDamage = 10;
    public int bounceCount = 1;
    public float bounceRange = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            // Deal damage in the radius
            if (gameObject.CompareTag("AOE"))
            {
                DealExplosiveDamage();
            }
            // Destroy the cube
            Destroy(gameObject);
        }
    }

    void DealExplosiveDamage()
    {
        // Find all colliders in the explosion radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("enemy"))
            {
                // Apply damage to enemies within the radius
                EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(explosionDamage);
                }
            }
        }
    }
}

