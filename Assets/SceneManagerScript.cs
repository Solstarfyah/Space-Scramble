using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    Scene scene;
    public HealthBarScript health; 

    private bool isPlaying;
    private bool levelDone; 


    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
        
        isPlaying = true; 
        levelDone = false; 
    }

    void FixedUpdate()
    {

    }

    private void Playing()
    {
        if (health.slider.value <= 0)
        {
            isPlaying = false;        
        }
        
    }

    private void checkStatus()
    {
        if ((isPlaying == false) && (levelDone == false)) // this basically checks to see if the player lost
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
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
