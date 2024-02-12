using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed = 10f;
    public GameObject coinPrefab; 
    public Rigidbody2D rb;

    void Awake()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject, 0.001f);
        
        if (collisionInfo.gameObject.tag == "blast")
        {
           Instantiate(coinPrefab, gameObject.transform.position, Quaternion.identity);
        }

    }
}