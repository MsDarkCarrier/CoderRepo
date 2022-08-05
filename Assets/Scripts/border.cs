using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Sol>())
        {
            collision.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
