using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;


public class PlayerCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    float next_spawn_time;
    public Transform LaunchOffset;
    public ObstacleScript ObstaclePrefab;
    public float randNumRng;

    void Start()
    {
        next_spawn_time = Time.time + 2.0f;
    }

    void Update()
    {
        float y = LaunchOffset.position.y + UnityEngine.Random.Range(-transform.position.y, randNumRng);
        Vector3 pos = LaunchOffset.position + new Vector3(0, y, 0);

        if (Time.time > next_spawn_time)
        {
            //do stuff here (like instantiate)
            Instantiate(ObstaclePrefab, pos, transform.rotation);

            //increment next_spawn_time
            next_spawn_time += 5.0f;
        }
    }
    
}
