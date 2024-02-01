using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Movement : MonoBehaviour
{
    public float moveSpeed;
    public HealthBarScript healthBar;
    public int maxFuel;

    [SerializeField]
    private float fuelBurnRate;

    
    private int currentFuel;
    
    private bool isFuel;
    private bool isMoving; // checks if player is moving forward
    
    
    private bool facingRight = true; // sets default player direction 
    private float XmoveDirection;
    private float YmoveDirection;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // looks for Rigidbody 2D component
        healthBar.SetMaxHealth(maxFuel);
        currentFuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        ProcessInputs();
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void ProcessInputs()
    { 
        XmoveDirection = Input.GetAxis("Horizontal");
        YmoveDirection = Input.GetAxis("Vertical");
        rb.velocity = new Vector2 (XmoveDirection * moveSpeed, YmoveDirection * moveSpeed);

        if(isMoving && isFuel)
        {
            currentFuel -= (int)( fuelBurnRate * Time.deltaTime);
            Debug.Log(currentFuel);
            healthBar.SetHealth( currentFuel );
        }
    }

    void OnCollisionEnter2D( UnityEngine.Collision2D col )
    {
        if (col.gameObject.tag == "fuel")
        {
            AddFuel(20);
        }
    }

    void AddFuel( int fuelPoints ) 
    {
        currentFuel += fuelPoints;
        healthBar.SetHealth(currentFuel);
    }

    void checkMovement()
    {
        isMoving = Input.GetKey(KeyCode.D);
        
        if (currentFuel != 0)
        {
            isFuel = true;
        }
        else 
        {
            isFuel = false;
        }
    }
}
