using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject bulletSpawnPoint; // Reference to the bullet spawn point
    public float shootingRange = 10f;
    public float shootingCooldown = 1f;
    public float bulletDestroyDelay = 1.0f;

    private float lastShootTime;

    void Update()
    {
        if (Time.time - lastShootTime > shootingCooldown)
        {
            Collider[] colliders = Physics.OverlapSphere(bulletSpawnPoint.transform.position, shootingRange);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("enemy"))
                {
                    ShootCube(collider.transform.position);
                    lastShootTime = Time.time;
                    break;
                }
            }
        }
    }

    void ShootCube(Vector3 targetPosition)
    {
        GameObject cube = Instantiate(cubePrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
        Rigidbody cubeRb = cube.GetComponent<Rigidbody>();
        if (cubeRb != null)
        {
            Vector3 shootDirection = (targetPosition - bulletSpawnPoint.transform.position).normalized;
            cubeRb.AddForce(shootDirection * 10f, ForceMode.Impulse);

            cube.AddComponent<CubeCollisionHandler>();
    }
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