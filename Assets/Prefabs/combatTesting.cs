using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;



public class combatTesting : MonoBehaviour
{
    float nextFire;
    Vector3 rotation;

    [Header("Both")]
    public int pHealth = 3;
    public Rigidbody2D rb;
    public float pFuelBar = 10;
    [Space(5)]

    [Header("Blast Settings")]

    public Transform blastOffset;
    public GameObject blastPrefab;
    public Transform RotatePoint;
    public float rotZ = 0;
    public float force;
    [Space(5)]

    public bool canFire;
    public float blastCD;
    public float timeBetweenFiring;
    [Space(5)]

    [Header("Parry Settings")]

    public bool canParry;
    public bool parried;
    public float pForce;
    public float timeBetweenParrying;
    public float parryBuffer;
    public float parryTimer = 0;
    public float parryCD = 0;


    // Start is called before the first frame update
    void Start()
    {
        parried = false;
        canParry = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            rotZ = 225;
            rotation = Vector3.down + Vector3.left;
        }

        else if (Input.GetKey("s"))
        {
            rotZ = 270;
            rotation = Vector3.down;
        }

        else if (Input.GetKey("a"))
        {
            rotZ = 180;
            rotation = Vector3.left;
        }

        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            rotZ = 135;
            rotation = Vector3.up + Vector3.left;

        }

        else if (Input.GetKey("w"))
        {
            rotZ = 90;
            rotation = Vector3.up;
        }

        if (Input.GetKey("d") && Input.GetKey("s"))
        {
            rotZ = 315;
            rotation = Vector3.down + Vector3.right;

        }
        else if (Input.GetKey("d"))
        {
            rotZ = 0;
            rotation = Vector3.right;

        }

        if (Input.GetKey("d") && Input.GetKey("w"))
        {
            rotZ = 45;
            rotation = Vector3.up + Vector3.right;

        }


        RotatePoint.transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            blastCD += Time.deltaTime;
            if (blastCD > timeBetweenFiring)
            {
                canFire = true;
                blastCD = 0;
            }
        }
        if (Input.GetKey("e") && canFire)
        {
            if (pFuelBar >= 1 && canFire == true)
            {
                canFire = false;
                blastCD = 0;
                Instantiate(blastPrefab, blastOffset.position, Quaternion.identity);
                rb.AddForce(-rotation * force, ForceMode2D.Force);
                pFuelBar -= 1;
            }
        }

        if (!canParry)
        {
            parryCD += Time.deltaTime;
            if (parryCD >= timeBetweenParrying)
            {
                canParry = true;
                parryCD = 0;
            }
        }

        if (Input.GetKey("f") && canParry)
        {
            parryTimer += Time.deltaTime;
            if (parryTimer <= parryBuffer)
            {
                parried = true;
                parryTimer += Time.deltaTime;
            }

            else if (parryTimer >= parryBuffer || Input.GetButton("f") == false)
            {
                parried = false;
                parryTimer = 0;
                canParry = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (parried != true)
        {
            pHealth -= 1;
        }

        else if (parried == true)
        {
            if (collisionInfo.collider.name == "ObstacleBase(Clone)")
            {
                rb.AddForce(Vector2.up * pForce, ForceMode2D.Force);
                pFuelBar += 1;
            }
        }
    }
}