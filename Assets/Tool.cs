using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public ToolSpawner ToolSpawner;
    public GameObject game_area;

    public float speed;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.up * (Time.deltaTime * speed); // every time this runs, object moves conssitently

        float distance = Vector3.Distance(transform.position, ToolSpawner.game_area.transform.position);
        if (distance > ToolSpawner.death_circle_radius)
        {
            RemoveShip();
        }
    }

    void RemoveShip()
    {
        Destroy(gameObject);
        ToolSpawner.toolCount --;
    }

}
