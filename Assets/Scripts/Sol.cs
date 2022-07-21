using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sol : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        Vector3 temporal = Input.mousePosition;
        Debug.Log(Vector3.Distance(gameObject.transform.position, temporal));
        /*if (Input.GetMouseButton(0) && Vector3.Distance(gameObject.transform.position,temporal) <= 1)
        {
            Destroy(gameObject);

        }*/
    }
}
