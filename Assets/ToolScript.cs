using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    public float speed = 2.0f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb.velocity = new Vector2(-speed, 0);
    }


    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject, 0.001f);
    }
}
