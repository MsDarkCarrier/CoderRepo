using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CasillaPosition : MonoBehaviour
{
    public bool disponible;
    public Transform objetivoPlantado;
    public GameObject platnaSobreMi;
    public UnityEvent <GameObject,CasillaPosition> evento;
    // Start is called before the first frame update
    void Start()
    {
        platnaSobreMi = null;
        disponible = true;  
    }

    // Update is called once per frame
    void Update()
    {
        if (evento != null)
        {
            if (!disponible) evento.Invoke(platnaSobreMi, GetComponent<CasillaPosition>());
            else evento.RemoveListener(GameManager.instancia.CasillaController);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planta")&&disponible)
        {
            evento.AddListener(GameManager.instancia.CasillaController);
            disponible = false;
        }
    }
}
