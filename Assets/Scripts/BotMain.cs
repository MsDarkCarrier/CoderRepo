using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotMain : MonoBehaviour
{
    [SerializeField] private GameObject uiMenuCarga;
    [SerializeField] private Image barra;
    [SerializeField] private Light[] luces;
    [SerializeField] private TextMeshProUGUI botTexto;
    [SerializeField] private AudioSource risas;

    [SerializeField] private GameObject panelNombre;
    [SerializeField] private TextMeshProUGUI nombreUsuario;
    [SerializeField] private ContenedorMundo datosJuego;

    private void Start()
    {
        panelNombre.SetActive(true);
        if (luces == null)
        {
            luces = new Light[2];
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Luces");
            for (int x = 0; x < temp.Length; x++)
            {
                luces[x] = temp[x].GetComponent<Light>();
            }
        }
    }

    public void Entrando()
    {
        for (int x = 0; x < luces.Length; x++)
        {
            luces[x].intensity = 13.62f;
        }
        botTexto.color=Color.white;
    }

    public void Saliendo()
    {
        for (int x = 0; x < luces.Length; x++)
        {
            luces[x].intensity = 4f;
        }
        botTexto.color = Color.gray;
    }

    public void Precionando()
    {
        StartCoroutine(ControladorBarra());
    }

    IEnumerator ControladorBarra()
    {
        uiMenuCarga.SetActive(true);
        risas.enabled = true;
        yield return new WaitForSeconds(3);
        AsyncOperation controladorCarga = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        while (!controladorCarga.isDone)
        {
            barra.fillAmount = controladorCarga.progress;
            yield return null;
        }
        
    }

    public void ObtenerNombreJugador()
    {
        if (nombreUsuario.text != "" || nombreUsuario.text != "tu nombre")
        {
            datosJuego.nombreJugador = nombreUsuario.text;
            Destroy(panelNombre);
        }
    }
}
