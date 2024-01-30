using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Movement : MonoBehaviour
{
    public float moveSpeed;
    
    private bool facingRight = true; // sets default player direction 
    private float XmoveDirection;
    private float YmoveDirection;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // looks for Rigidbody 2D component 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void ProcessInputs()
    { 
        XmoveDirection = Input.GetAxis("Horizontal");
        YmoveDirection = Input.GetAxis("Vertical");
    }
}
