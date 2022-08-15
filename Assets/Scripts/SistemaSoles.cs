using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SistemaSoles : MonoBehaviour
{
    public float tiempoMax;
    public float tiempoMin;
    public RectTransform[] limites = new RectTransform[2]; 
    public UnityEvent <RectTransform,RectTransform>caerSoles;

    void Start()
    {
        tiempoMax = Random.Range(5, 15);
        caerSoles.AddListener(GameManager.instancia.CrearSoles2D);
    }
    
    void Update()
    {
        tiempoMin += Time.deltaTime;
        if (tiempoMin >= tiempoMax && caerSoles!=null)
        {
            caerSoles.Invoke(limites[0], limites[1]);
            tiempoMin = 0;
        }
    }
}
