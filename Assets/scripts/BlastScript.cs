using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastScript : MonoBehaviour
{
    public combatTesting rotZ;
    public Transform RotatePoint;
    public Transform BlastOffset;
    private Rigidbody2D rb;
    private float time = 0.0f;
    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 rotation = RotatePoint.transform.position - BlastOffset.transform.position;
        Vector3 direction = BlastOffset.transform.position - RotatePoint.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject, 0.001f);
    }

    void Update()
    {
        time += Time.deltaTime; 
        if (time > 5.0f)
        {
            Destroy(gameObject, 0.001f);
        }
    }

    
}
