using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;

        float x = playerPos.x + 2;
        float y = playerPos.y + 1;
        float z = playerPos.z - 5;

        transform.position = new Vector3(x, y, z);
    }
}