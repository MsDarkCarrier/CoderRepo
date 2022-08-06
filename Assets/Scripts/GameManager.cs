using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int solMoneda,barraProgreso;
    private float cont;
    public bool terminar;
    public TextMeshProUGUI texto;
    public RectTransform progre,cab;
    public float tiempo;
    public Dictionary<GameObject,int> cartasJuego= new Dictionary<GameObject,int>();
    private Queue<GameObject> banderas = new Queue<GameObject>();
    private List<float> calculoPosiBanderas = new List<float>();
    public ContenedorMundo datosJuego;

    void Start()
    {
        cont = 0;
        instancia = this;
        texto = GameObject.FindWithTag("SolesText").GetComponent<TextMeshProUGUI>();
        solMoneda = 50;
        GameObject[]temporal= GameObject.FindGameObjectsWithTag("Banderas");
        foreach(GameObject objeto in temporal)
        {
            banderas.Enqueue(objeto);
        }
        calculoPosiBanderas = ObtenerCalculoBanderas();
    }

    void Update()
    {
            BarraProgreso();
            texto.text = Convert.ToString(solMoneda);
    }

    public List<float> ObtenerCalculoBanderas()
    {
        float banderaBarraPosition, banderasGrup=0;
        banderaBarraPosition = (665 * (100/(banderas.Count+1))) / 100;
        List<float> tiposBanderas = new List<float>();
        for(int temp=0; temp<=banderas.Count; temp++)
        {
            banderasGrup += banderaBarraPosition;
            tiposBanderas.Add(banderasGrup);
        }
        return tiposBanderas;

        //Esta funcion se encarga practicamente de calcular cual es el porcentaje que ocupan las banderas, para posteriormente asignarle un 
        //tamaño medible en relacion a la barra. Lo almacena en un list para posteriormente poder dividir en las posiciones.


    }

    public void BarraProgreso()
    {
        cont += Time.deltaTime;
        if (progre.sizeDelta.x >= 665f)
        {
            terminar = true;
            float temp = progre.sizeDelta.x - 1;
            progre.sizeDelta = new Vector2(temp, progre.sizeDelta.y);
            datosJuego.nivel++;

        }
        if (cont >= tiempo && !terminar)
        {
            cont = 0;
            float restaAnchuraBan = progre.sizeDelta.x + 0.5f;
            progre.sizeDelta = new Vector2(restaAnchuraBan, progre.sizeDelta.y);
            float restaPosiBan = progre.anchoredPosition.x - 0.23f;
            float restaPosiCab = cab.anchoredPosition.x - 0.419f;
            progre.anchoredPosition = new Vector2(restaPosiBan, progre.anchoredPosition.y);
            cab.anchoredPosition = new Vector2(restaPosiCab, cab.anchoredPosition.y);
        }
        

        for(int temp =0; temp<(calculoPosiBanderas.Count-1); temp++)
        {
            if (Convert.ToInt32(progre.sizeDelta.x) == calculoPosiBanderas[temp]) 
            {
                Debug.Log("Bandera:" + temp + " Alcanzada");
                calculoPosiBanderas[temp] -= 1;
                banderas.Dequeue().GetComponent<Bandera>().AlzarBandera();
                break;
            }
        }
    }
}
