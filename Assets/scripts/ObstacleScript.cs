using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed = 10f;
    public GameObject coinPrefab; 
    public Rigidbody2D rb;
    public CombatTypeSystem parried;

    void Awake()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject, 0.001f);
        
        if (collisionInfo.gameObject.tag != "Player" || parried == true)
        {
           Instantiate(coinPrefab, gameObject.transform.position, Quaternion.identity);
        }

    }
}