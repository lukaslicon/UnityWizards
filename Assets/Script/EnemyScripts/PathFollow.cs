using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public Transform[] pathNodes; // Array to store path nodes
    public float speed = 5.0f; // Movement speed

    private int currentNodeIndex = 0;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start()
    {
        if (pathNodes.Length > 0)
        {
            // Set initial position to the first node
            transform.position = pathNodes[0].position;
        }
        else
        {
            Debug.LogError("No path nodes assigned!");
        }
    }

    void Update()
    {
        if (pathNodes.Length == 0)
        {
            return;
        }

        // Move towards the current node
        MoveTowardsNode();

        // Check if the object has reached the current node
        if (Vector3.Distance(transform.position, pathNodes[currentNodeIndex].position) < 0.1f)
        {
            // Move to the next node
            currentNodeIndex = (currentNodeIndex + 1) % pathNodes.Length;
        }
    }

    void MoveTowardsNode()
    {
        // Move the object towards the current node
        Vector3 direction = Vector3.MoveTowards(transform.position, pathNodes[currentNodeIndex].position, speed * Time.deltaTime);

        float targetAngle = Mathf.Atan2(direction.x - transform.position.x, direction.z - transform.position.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(
            transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
            turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        transform.position = direction;
    }
}
