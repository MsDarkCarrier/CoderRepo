using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CartaMode : MonoBehaviour
{
    public GameObject prefabPlanta,cameras;
    public int costoPlanta;
    [SerializeField]private Camera mainCamera;
    [SerializeField] private bool precionando;
    private Vector3 posiMouse,temporal;

    private void Start()
    {
        mainCamera = Camera.main;
        
        precionando = false;
    }

    void Update()
    {
        
        Debug.Log(temporal);

        if (precionando)
        {
            
            if (Input.GetMouseButtonUp(0)) 
            {
                // Debug.Log();
                precionando = false;
            } 
            
        }
    }

    public void Precionar()
    {
        if (!precionando)
        {
            
            precionando = true;
        }
    }
}
