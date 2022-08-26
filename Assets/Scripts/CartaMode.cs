using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CartaMode : MonoBehaviour
{
    public GameObject prefabPlanta;
    private GameObject plantaCreada;
    [SerializeField]private uint costoPlanta;
    public bool casilla;
    [SerializeField] private bool precionando;

    private void Start()
    {       
        precionando = false;
        plantaCreada = null;
    }

    void Update()
    {
        if (precionando)
        {
            if (plantaCreada==null)
            {
                plantaCreada=Instantiate(prefabPlanta);
                plantaCreada.transform.position = GameManager.instancia.MousePosition();
                if(plantaCreada.GetComponent<LanzaGuizante>()) plantaCreada.GetComponent<LanzaGuizante>().enabled = false;
                if (plantaCreada.GetComponent<Girasol>()) plantaCreada.GetComponent<Girasol>();
                plantaCreada.GetComponent<Planta>().enabled = false;
            }
            else
            {
                plantaCreada.transform.position = GameManager.instancia.MousePosition();
            }

            if (Input.GetMouseButtonUp(0))
            {
                GameManager.instancia.CasillaControler(prefabPlanta, costoPlanta);
                Destroy(plantaCreada);
                precionando = false;
            }

        } 
    }

    public void Precionar()
    {
        if (!precionando)
        {
            if (GameManager.instancia.solMoneda >= costoPlanta) precionando = true;
             
        }
        
    }

    public void FaltanSoles()
    {

        if (costoPlanta>=GameManager.instancia.solMoneda) StartCoroutine(GameManager.instancia.FaltanSoles());
        
    }
}
