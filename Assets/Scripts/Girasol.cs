using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girasol : MonoBehaviour
{
    public GameObject SolPrefab;
    public GameObject SolSpawn,temporal;
    public float tiempoActual = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (!GameManager.instancia.pausa) 
        {
            if (GetComponent<Planta>().vida <= 0) Destroy(gameObject);
            ComienzaTiempo();
        }
    }

    void ComienzaTiempo()
    {
        tiempoActual += Time.deltaTime;
        if (tiempoActual >= 24f)
        {
            StartCoroutine(FisicaSoles());
            tiempoActual = 0f;
        }


    }

    IEnumerator FisicaSoles()
    {
        temporal = Instantiate(SolPrefab);
        temporal.GetComponent<Animator>().enabled = false;
        temporal.transform.position = SolSpawn.transform.position;
        temporal.GetComponent<Rigidbody>().AddForce(Vector3.up * 500f);
        yield return new WaitForSeconds(1f);
        try
        {
            Destroy(temporal.GetComponent<Rigidbody>());
            temporal.GetComponent<Animator>().enabled = true;
            temporal.GetComponent<Animator>().SetBool("mov", true);

        }
        catch(Exception) { }
        
    }
}
