using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Movement : MonoBehaviour
{
    public float moveSpeed;
    public HealthBarScript healthBar;
    public CountDownBar oxygen;
    
    public int maxFuel;
    public int timeBonus;
    public int timeDeduction;
    public int fuelBonus;
    
    public Transform sceneTop;
    public Transform sceneBottom;

    public Transform sceneLeft;
    public Transform sceneRight;

    private float fuelBurnRate = 60;

    
    private int currentFuel;
    
    private bool isFuel;
    private bool isMoving = false; // checks if player is moving forward
    
    
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


    private void FixedUpdate()
    {
        if (isMoving & isFuel)
        {
            currentFuel = currentFuel - ((int)(fuelBurnRate * Time.deltaTime));
            healthBar.SetHealth(currentFuel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        checkMovement();

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

    }

    void OnCollisionEnter2D( Collision2D col )
    {
        if (col.gameObject.tag == "fuel")
        {
            AddFuel(fuelBonus);
        }
   
        else if (col.gameObject.tag == "oxygen")
        {
            AddOxygen(timeBonus);
        }
      
        else if (col.gameObject.tag == "obstacle")
        {
            AddOxygen(timeDeduction);
        }

        Destroy(col.gameObject);
    }

    void AddFuel( int fuelPoints ) 
    {
        currentFuel += fuelPoints;
        healthBar.SetHealth(currentFuel);
    }
    
    void AddOxygen( int oxygenPoints )
    {
        oxygen.countdownBar.value += oxygenPoints;
    }

    void checkMovement()
    {
        isMoving = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S));



        if (currentFuel > 0)
        {
            isFuel = true;
            moveSpeed = 2;
        }
        else 
        {
            isFuel = false;
            moveSpeed = 1;
        }
    }
}
