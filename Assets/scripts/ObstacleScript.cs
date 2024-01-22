using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject, 0.001f);
    }
}
