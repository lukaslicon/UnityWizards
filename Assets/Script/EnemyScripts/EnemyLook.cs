using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        // Calculate movement direction based on the current rotation
        Vector3 direction = transform.forward;

        // Move the enemy forward
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Optional: You can add additional logic to change the direction based on other factors
    }
}