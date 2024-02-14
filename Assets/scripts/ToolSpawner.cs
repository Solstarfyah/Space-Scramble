using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSpawner : MonoBehaviour
{
    public GameObject game_area;
    public List<GameObject> objectPrefabs = new List<GameObject>();
    private GameObject toolPrefab; // tool prefab == any random game object

    public int toolCount = 0;
    public int toolLimit = 20;
    public int toolsPerFrame = 1;
    public int randNum;

    public float spawn_circle_radius = 50.0f;
    public float death_circle_radius = 60.0f;

    public float fastest_speed = 12.0f;
    public float slowest_speed = 0.75f;

    void Start()
    {
        toolPrefab = objectPrefabs[0];
        InitialPopulation();
    
    }

    void InitialPopulation() // this is used to avoid having to wait for tools to appear onscreen 
    {
        for (int i = 0; i < toolLimit; i++)
        {
            Vector3 position = GetRandomPosition(true);
            Tool ToolScript = AddTool(position, toolPrefab);
            ToolScript.transform.Rotate(Vector3.forward * Random.Range(0f, 360f));

        }
    }

    void Update()
    {
        MaintainPopulation();

        randNum = Random.Range(0, objectPrefabs.Count);

        // Set toolPrefab based on randNum
        if (randNum >= 0 && randNum < objectPrefabs.Count)
        {
            toolPrefab = objectPrefabs[randNum];
        }
        else
        {
            Debug.LogError("Invalid randNum generated!");
        }
    }

    void MaintainPopulation()
    {
        if (toolCount < toolLimit)
        {
            for (int i = 0; i < toolsPerFrame; i++)
            {
                Vector3 position = GetRandomPosition(false);

                // Pass the prefab directly to AddTool
                Tool ToolScript = AddTool(position, toolPrefab);

                ToolScript.transform.Rotate(Vector3.forward * Random.Range(-45.0f, 45.0f));
            }
        }
    }

    Vector3 GetRandomPosition(bool withinCamera)
    {
        Vector3 position = Random.insideUnitCircle;

        if (withinCamera == false)
        {
            position = position.normalized;
        }

        position *= spawn_circle_radius;
        position += game_area.transform.position;

        return position;
    }

    Tool AddTool(Vector3 position, GameObject prefab)
    {
        toolCount += 1;
        GameObject newTool = Instantiate(
            prefab,
            position,
            Quaternion.FromToRotation(Vector3.up, (game_area.transform.position - position)),
            gameObject.transform
        );

        Tool ToolScript = newTool.GetComponent<Tool>();
        ToolScript.ToolSpawner = this;
        ToolScript.game_area = game_area;
        ToolScript.speed = Random.Range(slowest_speed, fastest_speed);

        return ToolScript;
    }
}
