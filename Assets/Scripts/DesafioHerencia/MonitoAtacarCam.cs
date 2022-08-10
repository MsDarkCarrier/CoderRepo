using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoAtacarCam : MonitoManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectarEnemigo())
        {
            Caminar();
            if (distanciaEnemi <= 2f) 
            {
                caminar = false;
                Atacando();
            }
            else
            {
                caminar = true;
            }
        } else Debug.Log("No hay enemigo a la vista");
    }
    
}
