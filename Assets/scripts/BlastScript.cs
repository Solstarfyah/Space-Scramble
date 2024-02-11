using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private float time = 0.0f;
    public float force;

    void Start()
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
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
