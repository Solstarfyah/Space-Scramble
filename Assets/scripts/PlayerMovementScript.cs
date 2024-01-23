using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 3f;
    public float jumpHeight = 1f;
    private Rigidbody2D rb;

    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();

        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight));
        }
    }
}