using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int solMoneda;
    public TextMeshProUGUI texto;

    void Start()
    {
        instancia = this;
        texto = GameObject.FindWithTag("SolesText").GetComponent<TextMeshProUGUI>();
        solMoneda = 50;
    }

    void Update()
    {
        texto.text = Convert.ToString(solMoneda);
    }

    public void ASFSDAF()
    {

    }
}
