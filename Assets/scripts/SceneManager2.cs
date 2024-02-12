using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour
{
    public CountDownBar oxygen;

    private bool isPlaying;

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

    }

    private void CheckStatus()
    {
        if (isPlaying == false)
        {
            SceneManager.LoadScene("gameOver");
        }

    }
}
