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
    public float tIncrement;

    public CoinCounter coins;

    void Start()
    {
        next_spawn_time = Time.time + tIncrement;
    }

    void Update()
    {

        if (Time.time > next_spawn_time)
        {
            float y = LaunchOffset.position.y + UnityEngine.Random.Range((-2 * LaunchOffset.position.y - 1), randNumRng);
            Vector3 pos = LaunchOffset.position + new Vector3(0, y, 0);

            Instantiate(ObstaclePrefab, pos, transform.rotation);

            //increment next_spawn_time
            next_spawn_time += tIncrement;
            next_spawn_time -= 0.5f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            coins.numCoins += 1;
        }
    }
    
}
