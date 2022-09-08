using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]private GameObject panelMenu;
    private GameObject[] sol2DArray;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& GameManager.instancia.contenedorJugable.activeInHierarchy)
        {
            sol2DArray = GameObject.FindGameObjectsWithTag("Soles2D");
            foreach (GameObject soles2D in sol2DArray)
            {
                soles2D.SetActive(false);
            }
            GameManager.instancia.contenedorJugable.SetActive(false);
            panelMenu.SetActive(true);
            GameManager.instancia.pausa = true;
            GameManager.instancia.musicaAmbiente.mute = true;
        }
    }

    public void BotRegresar()
    {
        foreach (GameObject soles2D in sol2DArray)
        {
            soles2D.SetActive(true);
        }
        GameManager.instancia.contenedorJugable.SetActive(true);
        panelMenu.SetActive(false);
        GameManager.instancia.pausa = false;
        GameManager.instancia.musicaAmbiente.mute = false;
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
