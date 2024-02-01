using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    public static bool allowInputs;

    public Slider countdownBar;
    private bool countDown = true;

    public float countDownTime = 8;
    public float refillTime = 10;

    private void Start()
    {
        //Set the max value to the refill time
        countdownBar.maxValue = refillTime;
    }

    private void Update()
    {
        if (countdownBar.maxValue != refillTime)
        {
            countdownBar.maxValue = refillTime;           
        }

        if (countDown) //Scale the countdown time to go faster than the refill time
        {
            countdownBar.value -= Time.deltaTime / countDownTime * refillTime;
        }
       
        else
        {
            countdownBar.value += Time.deltaTime;
        }


        //If we are at 0, start to refill
        /*if (countdownBar.value <= 0)
        {
            countDown = false;
            allowInputs = false;
        }
        
        else if (countdownBar.value >= refillTime)
        {
            countDown = true;
            allowInputs = true;
        }*/
    }

    void CheckInput()
    {
        if (!CountDownBar.allowInputs)
            return;

        //Your code for handling inputs
    }
}