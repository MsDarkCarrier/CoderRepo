using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borde : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Sol>())
        {
            Destroy(collision.GetComponent<Rigidbody2D>());
            collision.GetComponent<CircleCollider2D>().enabled = false;
            
        }
        
    }
}
