using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
    public GameObject cubePrefab;
    public float shootingRange = 10f;
    public float shootingCooldown = 1f;
    public float bulletDestroyDelay = 5.0f;

    private float lastShootTime;

    public float bulletDestroyDelay = 5.0f;

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

        }cube.AddComponent<CubeCollisionHandler>();
    }
}


public class CubeCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("enemy")){
        Destroy(gameObject);
         }
    }
}
