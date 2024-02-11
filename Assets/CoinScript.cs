using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Transform blastPrefab; 
    public float speed = 10f;
    public Rigidbody2D rb;


    void Awake()
    {
        rb.velocity = new Vector2(-speed, 0);
    }
    


    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.001f);
        }
    }


}
