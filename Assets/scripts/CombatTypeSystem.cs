using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CombatTypeSystem : MonoBehaviour
{

    float pbx;
    float pby;
    float nextFire;

    [Header("Both")]
    public int pHealth = 3;
    public Rigidbody2D rb;
    public float pFuelBar = 10;
    [Space(5)]

    [Header("Blast Settings")]

    public Transform blastOffset;
    public GameObject blastPrefab;
    public Transform RotatePoint;
    public float force;
    [Space(5)]

    public bool canFire;
    public float blastCD;
    public float timeBetweenFiring;
    public float rightOrUp;
    public float leftOrDown;
    public float diagonalFire;
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
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);


        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        

        RotatePoint.transform.rotation;
        
        */


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
                fireUpRight();
                fireUpLeft();
                fireDownRight();
                fireDownLeft();
                //rb.AddForce(rotation * force, ForceMode2D.Impulse);
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

        void CreatePlayerBullet()
        {
            Instantiate(blastPrefab, blastOffset.position, Quaternion.identity);
        }

        void fireDownLeft()
        {
            if (Input.GetKey("s") && Time.time > nextFire && Input.GetKey("a"))
            {
                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = leftOrDown * diagonalFire;
                pby = leftOrDown * diagonalFire;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }
            else if (Input.GetKey("s") && Time.time > nextFire)
            {
                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = 0;
                pby = leftOrDown;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }
            else if (Input.GetKey("a") && Time.time > nextFire)
            {
                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = leftOrDown;
                pby = 0;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }
        }



        void fireUpLeft()
        {
            if (Input.GetKey("a") && Time.time > nextFire && Input.GetKey("w"))
            {
                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = leftOrDown * diagonalFire;
                pby = rightOrUp * diagonalFire;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }

            else if (Input.GetKey("w") && Time.time > nextFire)
            {
                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = 0;
                pby = rightOrUp;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }
        }

        void fireDownRight()
        {
            if (Input.GetKey("d") && Time.time > nextFire && Input.GetKey("s"))
            {
                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = rightOrUp * diagonalFire;
                pby = leftOrDown * diagonalFire;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }
            else if (Input.GetKey("d") && Time.time > nextFire)
            {
                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = rightOrUp;
                pby = 0;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }

        }

        void fireUpRight()
        {
            if (Input.GetKey("d") && Time.time > nextFire && Input.GetKey("w"))
            {

                nextFire = Time.time + timeBetweenFiring;
                CreatePlayerBullet();
                pbx = rightOrUp * diagonalFire;
                pby = rightOrUp * diagonalFire;
                BulletMovement.velX = pbx;
                BulletMovement.velY = pby;
            }

        }

        void FixedUpdate()
        {
            fireUpRight();
            fireUpLeft();
            fireDownRight();
            fireDownLeft();
        }

        void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (parried != true)
            {
                pHealth -= 1;
            }

            else if (parried == true)
            {
                if (collisionInfo.collider.name == "ObstacleBase(Clone)")
                {
                    rb.AddForce(Vector2.up * pForce, ForceMode2D.Impulse);
                    pFuelBar += 10;
                }
            }
        }
    }
}

