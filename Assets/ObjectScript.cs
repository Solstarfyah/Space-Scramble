using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    void OnCollisioneEnter2D( Collision2D collision)
    {
        Destroy( gameObject );
    }
}
