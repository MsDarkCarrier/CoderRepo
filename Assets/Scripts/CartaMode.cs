using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CartaMode : MonoBehaviour
{
    public GameObject prefabPlanta;
    private GameObject plantaCreada;
    public TextMeshPro textoCostoPlanta;
    public bool casilla;
    public int costoPlanta;
    [SerializeField] private bool precionando;
    private Vector3 posiMouse,temporal;

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
                if (casilla)
                {
                    Instantiate(prefabPlanta).transform.position= GameManager.instancia.MousePosition();
                    GameManager.instancia.EliminarSoles(Convert.ToUInt16(textoCostoPlanta.text));
                    Destroy(plantaCreada);
                }
                else Destroy(plantaCreada);
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
