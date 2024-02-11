using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    Scene scene;
    public HealthBarScript health; 
    public CoinCounter coins; 
    public CountDownBar oxygen;

    private bool isPlaying;
    private bool levelDone; 


    void Start()
    {
        scene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(gameObject);
        
        isPlaying = true; 
        levelDone = false; 
    }

    void Update()
    {
        if (scene.name == "Main")
        {
            Playing();
            checkStatus();
        }

        if (scene.name == "LVL 2-3")
        {
            playing1();
            checkStatus2();
        }
        
    }

    private void Playing() // checks to see if the player went down to 0 health or got the req number of coins 
    {
        if (health.slider.value <= 0)
        {
            isPlaying = false;        
        }

        if (coins.numCoins == 25)
        {
            levelDone = true;
        }
        
    }

    private void checkStatus()
    {
        if ((isPlaying == false) && (levelDone == false)) // this basically checks to see if the player lost
        {
            SceneManager.LoadScene("gameOver");
        }
        
        else if ( (isPlaying == true) && (levelDone == true))
        {
            SceneManager.LoadScene("LVL 2-3");
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            isPlaying = true;
            levelDone = true;
            SceneManager.LoadScene("LVL 2-3");
        }
    }

    private void playing1()
    {
        if (oxygen.countdownBar.value <= 0)
        {
            isPlaying = false;
        }

    }

    private void checkStatus2()
    {
        if (isPlaying == false)
        {
            SceneManager.LoadScene("gameOver");
        }

    }

    
    /*void OnGUI()
    {
        GUI.skin.button.fontSize = 20;

        if (GUI.Button(new Rect(10, 80, 180, 60), "Change from scene " + scene.buildIndex))
        {
            int nextSceneIndex = Random.Range(0, 4);
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }
    }*/
}
