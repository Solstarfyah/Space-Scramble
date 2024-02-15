using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour
{
    public CountDownBar oxygen;
    public CoinCounter toolCounter;


    private bool isPlaying;
    private bool levelComplete;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        Playing();
        CheckStatus();
        
    }

    private void Playing()
    {
        if (oxygen.countdownBar.value <= 0)
        {
            isPlaying = false;
        }

        if (toolCounter.numCoins >= 15)
        {
            levelComplete = true;
        }

    }

    private void CheckStatus()
    {
        if (isPlaying == false)
        {
            SceneManager.LoadScene("gameOver");
        }

        if (levelComplete)
        {
            SceneManager.LoadScene("gameOver");
        }

    }
}
