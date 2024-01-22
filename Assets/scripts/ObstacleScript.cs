using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    float speed = 10f;


    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject, 0.001f);
    }
}
