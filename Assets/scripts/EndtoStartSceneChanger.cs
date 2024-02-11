using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndtoStartSceneChanger : MonoBehaviour
{
    public void loadLevelScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
