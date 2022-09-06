using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]private GameObject panelMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& GameManager.instancia.contenedorJugable.activeInHierarchy)
        {
            GameManager.instancia.contenedorJugable.SetActive(false);
            panelMenu.SetActive(true);
            GameManager.instancia.pausa = true;
            GameManager.instancia.musicaAmbiente.enabled = false;
        }
    }

    public void BotRegresar()
    {
        GameManager.instancia.contenedorJugable.SetActive(true);
        panelMenu.SetActive(false);
        GameManager.instancia.pausa = false;
        GameManager.instancia.musicaAmbiente.enabled = true;
    }
    public void BotReiniciar()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void BotInicio()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
