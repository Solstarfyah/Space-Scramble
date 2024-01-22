using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // other project notes
    // Jump key has been hardcoded to W 
    // to fix the player getting stuck create a new physics 2D material and add to player && reduce friction to 0 

    public float moveSpeed;
    public float jumpForce; // will probably have to be some value around 300 
    public float checkRadius; // default to 1.5 

    // these prevent the player from colliding w/ other stuff when jumping 
    // ensure that there is a new, separate layer called ground. add all platforms to this layer 
    // player needs child empties called ceilingCheck & groundCheck 
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;

    private Rigidbody2D rb;
    private bool facingRight = true; // default direction for player movement 
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;
    public int maxJumpCount;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // looks for Rigidbody 2D component 
    }

    private void Move()
    {

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpCount = maxJumpCount;
        }
        isJumping = false;

    }

    void Update()
    {
        ProcessInputs();
        Animate();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, checkRadius, groundObjects);
        Move(); // better for physics 
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // input player movement (LOCKED TO X AXIS) 

        if (/*(Input.GetKeyDown(KeyCode.Space) ||*/ (Input.GetKeyDown(KeyCode.W)) && isGrounded) & jumpCount > 0)
        {
            isJumping = true;
            jumpCount--;
        }
    }

    private void Animate()
    {
        if ((moveDirection > 0) && !facingRight) // pos movement + wrong direction --> change in direction 
        {
            FlipCharacter();
        }
        else if ((moveDirection < 0) && facingRight) // neg movement --> change in direction 
        {
            FlipCharacter();
        }

    }

}
