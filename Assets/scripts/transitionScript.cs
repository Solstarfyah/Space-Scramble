using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionScript : MonoBehaviour
{
    public float holdTime = 3.0f; // how long you need to hold to trigger the effect

    private float startTime = 0f;
    private float timer = 0f;

    // Use if you only want to call the method once after holding for the required time
    private bool held = false;

    public void Update()
    {
        HandleGameExit();
       // HandleGamepadInputs();
       // HandleMameInputs();
       // HandleMouseInputs();
    }

    // This will check to see if the Escape key has been held down for holdTime time
    private void HandleGameExit()
    {
        string key = "escape";

        // Starts the timer from when the key is pressed
        if (Input.GetKeyDown(key))
        {
            startTime = Time.time;
            timer = startTime;
        }

        // Adds time onto the timer so long as the key is pressed
        if (Input.GetKey(key) && held == false)
        {
            timer += Time.deltaTime;

            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
            if (timer > (startTime + holdTime))
            {
                held = true;
                EscapeButtonHeld();
            }
        }

        // For single effects. Remove if not needed
        if (Input.GetKeyUp(key))
        {
            held = false;
        }

    }

    // Method called after held for required time
    void EscapeButtonHeld()
    {
        Debug.Log("held for " + holdTime + " seconds");
        Application.Quit();
    }


    private void HandleMouseInputs()
    {
        float horizontalSpeed = 2.0f;
        float verticalSpeed = 2.0f;

        // Get the mouse delta. This is not in the range -1...1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        string msg = string.Format("{0} - {1}", h, v);
        //Debug.Log(msg);
        transform.Rotate(v, h, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed secondary button.");
        }

        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Pressed middle click.");
        }
    }

    private void HandleGamepadInputs()
    {

        // Upper Left game pad
        string msg = "";

        /////////////////////////////////////////
        // 1 - 4 buttons on top of gamepad
        /////////////////////////////////////////
        if (Input.GetKey("joystick button 0"))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "BUTTON 1";
        }
        if (Input.GetKey("joystick button 1"))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "BUTTON 2";
        }
        if (Input.GetKey("joystick button 2"))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "BUTTON 3";
        }
        if (Input.GetKey("joystick button 3"))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "BUTTON 4";
        }

        /////////////////////////////////////////
        // 5 - 9 buttons on front of gamepad
        /////////////////////////////////////////
        if (Input.GetKey("joystick button 4"))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "BUTTON 5";
        }
        if (Input.GetKey("joystick button 5"))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "BUTTON 6";
        }
        if (Input.GetKey("joystick button 6"))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "BUTTON 7";
        }
        if (Input.GetKey("joystick button 7"))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "BUTTON 8";
        }



        /////////////////////////////////////////
        // Arrow keys
        /////////////////////////////////////////
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "LeftArrow";
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "RightArrow";
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "UpArrow";
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "DownArrow";
        }


        /////////////////////////////////////////////
        // Right Side Quad Buttons
        /////////////////////////////////////////////
        //1
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Control Button - 1";
        }
        //2
        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "Control Button - 2";
        }
        //3
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Control Button - 3";
        }
        //4
        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Control Button - 4";
        }



        /////////////////////////////////////////////
        // Top Control Buttons 
        /////////////////////////////////////////////
        //8
        if (Input.GetKey(KeyCode.Joystick1Button8))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Top Control Upper Left Button - 8";
        }

        //9
        if (Input.GetKey(KeyCode.Joystick1Button9))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Top Control Upper Right Button - 9";
        }


        /////////////////////////////////////////////
        //  Axis - Lower left stick
        /////////////////////////////////////////////
        float val = Input.GetAxis("Vertical1");
        if (Mathf.Floor(val) != 0)
        {
            Vector2 newDirection = Vector2.up * val;
            MoveObject(newDirection);
            msg = "Joy LowLeft - Vertical";
        }

        val = Input.GetAxis("Horizontal1");
        if (Mathf.Floor(val) != 0)
        {
            Vector2 newDirection = Vector2.left * -val;
            MoveObject(newDirection);
            msg = "Joy LowLeft - Horizontal";
        }


        /////////////////////////////////////////////
        // Axis - Lower right stick
        /////////////////////////////////////////////
        float val_v = Input.GetAxis("Vertical2");
        if (Mathf.Floor(val_v) != 0)
        {
            Vector2 newDirection = Vector2.up * val_v;
            MoveObject(newDirection);
            msg = "Joy LowRight - Vertical";
        }

        float val_h = Input.GetAxis("Horizontal2");
        if (Mathf.Floor(val_h) != 0)
        {
            Vector2 newDirection = Vector2.left * -val_h;
            MoveObject(newDirection);
            msg = "Joy LowRight - Horizontal";
        }

        /////////////////////////////////////////////
        //  Axis - Upper left quad pad
        /////////////////////////////////////////////
        val = Input.GetAxis("Vertical3");
        if (Mathf.Floor(val) != 0)
        {
            Vector2 newDirection = Vector2.up * -val;
            MoveObject(newDirection);
            msg = "Joy UpperLeft - Vertical";
        }

        val = Input.GetAxis("Horizontal3");
        if (Mathf.Floor(val) != 0)
        {
            Vector2 newDirection = Vector2.left * -val;
            MoveObject(newDirection);
            msg = "Joy UpperLeft - Horizontal";
        }


        // Show which button was pressed
        if (msg != "")
            Debug.Log(msg);
    }



    private void HandleMameInputs()
    {

        ///////////////////////////////////////////
        //  Default Keymap	
        ///////////////////////////////////////////
        /* Main Keys	
        5,6,7,8	   Insert coin	
        1,2,3,4	   Players 1 - 4 start buttons	
        
        Arrow Keys	Controller (Player 1)	
        
        Left Ctrl	Fire 1 (Player 1)	
        Left Alt	Fire 2 (Player 1)	
        Space	    Fire 3 (Player 1)	
        Left Shift	Fire 4 (Player 1)	
        Z	        Fire 5 (Player 1)	
        X           Fire 6(Player 1)	
        
        R,F,G,D	Controller (Player 2)	
        A         Fire 1 (Player 2)	
        S         Fire 2 (Player 2)	
        Q         Fire 3 (Player 2)	
        W         Fire 4 (Player 2)	
        E         Fire 5 (Player 2)	Not set by default
        T         Fire 6 (Player 2)	Not Set By Default	
        
        Playchoice 10 Additional Keys	
        5         Adds Time	
        0         Select Game	
        1         Toggles 1 or 2 Player Mode	
        2         Start Game
        */

        string msg = "";

        /////////////////////////////////////////////
        // Control Keys
        /////////////////////////////////////////////
        // Player 1 - Start
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "Button - Player 1 Start";
        }
        // Player 2 - Start
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "Button - Player 2 Start";
        }

        // Coin 1
        if (Input.GetKey(KeyCode.Alpha5))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Button - Coin 1";
        }
        // Coin 2
        if (Input.GetKey(KeyCode.Alpha6))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Button - Coin 2";
        }

        // Coin 2
        if (Input.GetKey(KeyCode.Alpha6))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Button - Coin 2";
        }

        /////////////////////////////////////////////
        // Player 1 Movements
        /////////////////////////////////////////////
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Player 1 - LeftArrow";
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Player 1 - RightArrow";
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Player 1 - UpArrow";
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "Player 1 - DownArrow";
        }


        /////////////////////////////////////
        // Player 1 Actions
        /////////////////////////////////////
        // Left Ctrl   Fire 1(Player 1)
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Fire 1(Player 1)";
        }

        // Left Alt    Fire 2(Player 1)
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Fire 2(Player 1)";
        }

        // Space Fire 3(Player 1)
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Fire 3(Player 1)";
        }

        // Left Shift  Fire 4(Player 1)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "Fire 4(Player 1)";
        }

        // Z Fire 5(Player 1)
        if (Input.GetKey(KeyCode.Z))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Fire 5(Player 1)";
        }

        // X Fire 6(Player 1)
        if (Input.GetKey(KeyCode.X))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Fire 6(Player 1)";
        }




        /////////////////////////////////////////////
        // Player 2 Movements
        /////////////////////////////////////////////
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Player 2 - LeftArrow";
        }
        if (Input.GetKey(KeyCode.G))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Player 2 - RightArrow";
        }
        if (Input.GetKey(KeyCode.R))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Player 2 - UpArrow";
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            msg = "Player 2 - DownArrow";
        }


        /////////////////////////////////////
        // Player 2 Actions
        /////////////////////////////////////

        // A   Fire 1(Player 2)
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            msg = "Fire 1(Player 2)";
        }

        // S   Fire 2(Player 2)
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Fire 2(Player 2)";
        }

        // Q   Fire 3(Player 2)
        if (Input.GetKey(KeyCode.Q))
        {
            Vector2 newDirection = Vector2.up;
            MoveObject(newDirection);
            newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Fire 3(Player 2)";
        }

        // W   Fire 4(Player 2)
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 newDirection = Vector2.down;
            MoveObject(newDirection);
            newDirection = Vector2.right;
            MoveObject(newDirection);
            msg = "Fire 4(Player 2)";
        }

        // NOT DEFAULT - E   Fire 5(Player 2)
        if (Input.GetKey(KeyCode.E))
        {
            Vector2 newDirection = Vector2.left;
            MoveObject(newDirection);
            newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Fire 5(Player 2)";
        }

        // NOT DEFAULT - T   Fire 6(Player 2)
        if (Input.GetKey(KeyCode.T))
        {
            Vector2 newDirection = Vector2.right;
            MoveObject(newDirection);
            newDirection = Vector2.up;
            MoveObject(newDirection);
            msg = "Fire 6(Player 2)";
        }



        // Show which button was pressed
        if (msg != "")
        {
            Debug.Log(msg);
        }
    }


    private void MoveObject(Vector2 direction)
    {
        float speed = 4.0f;

        float dx = direction.x;
        float dy = direction.y;

        Vector3 pos = gameObject.transform.position;
        pos.x += dx * speed * Time.deltaTime;
        pos.y += dy * speed * Time.deltaTime;
        gameObject.transform.position = pos;
    }
}
