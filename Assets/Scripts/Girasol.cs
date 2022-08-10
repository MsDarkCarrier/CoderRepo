using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girasol : MonoBehaviour
{
    [SerializeField]private GameObject SolPrefab;
    public GameObject SolSpawn,temporal;
    public float tiempoActual = 0f;

    void Update()
    {
        if (GetComponent<Planta>().vida <= 0) Destroy(gameObject);
        ComienzaTiempo();
    }

    void ComienzaTiempo()
    {
        tiempoActual += Time.deltaTime;
        if (tiempoActual >= 24f)
        {
            temporal=Instantiate(SolPrefab, SolSpawn.transform.position, transform.rotation);
            tiempoActual = 0f;
        }


    }
}
