using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaPosition : MonoBehaviour
{
    public bool disponible;
    public Transform objetivoPlantado;
    // Start is called before the first frame update
    void Start()
    {
        disponible = true;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planta")&&disponible)
        {
            disponible = false;
        }
    }
}
