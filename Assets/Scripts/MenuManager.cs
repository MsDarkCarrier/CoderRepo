using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject botAventura;
    public GameObject panelNombre;
    public TextMeshProUGUI nombreUsuario;
    public ContenedorMundo datosJuego;
    void Start()
    {
        botAventura.SetActive(false);
    }
    void Update()
    {
        
    }
    public void EscenaNivel()
    {
        if (datosJuego.nivel == 0)
        {
            SceneManager.LoadScene("GameScene");
        }

    }

    public void ObtenerNombreJugador()
    {
        if (nombreUsuario.text != "")
        {
            datosJuego.nombreJugador = nombreUsuario.text;
            Destroy(panelNombre);
            botAventura.SetActive(true);
        }
    }



}
