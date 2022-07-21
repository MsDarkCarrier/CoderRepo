using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girasol : MonoBehaviour
{
    public GameObject SolPrefab;
    public GameObject SolSpawn;
    public float tiempoActual = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        ComienzaTiempo();
    }

    void ComienzaTiempo()
    {
        tiempoActual += Time.deltaTime;
        if (tiempoActual >= 5f)
        {
            Instantiate(SolPrefab, SolSpawn.transform.position, transform.rotation);
            tiempoActual = 0f;
        }


    }
}
