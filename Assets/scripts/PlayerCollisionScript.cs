using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    float next_spawn_time;
    public Transform LaunchOffset;
    public ObstacleScript ObstaclePrefab;

    void Start()
    {
        next_spawn_time = Time.time + 5.0f;
    }

    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            //do stuff here (like instantiate)
            Instantiate(ObstaclePrefab, LaunchOffset.position, transform.rotation);

            //increment next_spawn_time
            next_spawn_time += 5.0f;
        }
    }
    
}
