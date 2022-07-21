using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int SolMoneda;
    public TextMeshPro texto;

    private void Awake()
    {
        texto = GameObject.FindWithTag("GameController").GetComponent<TextMeshPro>();
    }
    void Start()
    {
        instancia = this;
        SolMoneda = 50;
    }

    void Update()
    {
        Debug.Log(texto.text);
    }

    public void ASFSDAF()
    {

    }
}
