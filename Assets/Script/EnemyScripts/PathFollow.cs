using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public Transform[] pathNodes; // Array to store path nodes
    public float speed = 5.0f; // Movement speed

    private int currentNodeIndex = 0;

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
        transform.position = Vector3.MoveTowards(transform.position, pathNodes[currentNodeIndex].position, speed * Time.deltaTime);
    }
}
