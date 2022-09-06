using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject contenedorJugable;
    [SerializeField] private AudioSource faltaSoles, sonidoPlantado, recogidaSol, recogidaSolDos;
    public AudioSource musicaAmbiente;
    public static GameManager instancia;
    public Camera camera2D;
    public GameObject soles2D, soles3D;
    public uint solMoneda, barraProgreso;
    public bool terminar,pausa;
    public TextMeshProUGUI texto;
    public ContenedorMundo datosJuego;
    [SerializeField] private GameObject[] casiPos = new GameObject[30];

    void Start()
    {
        pausa = false;
        instancia = this;
        if(contenedorJugable.activeInHierarchy) texto = GameObject.FindWithTag("SolesText").GetComponent<TextMeshProUGUI>();
        solMoneda = 50;
        casiPos = GameObject.FindGameObjectsWithTag("CasillasPlantas");

    }

    void Update()
    {
        texto.text = System.Convert.ToString(solMoneda);
    }

    public void CrearSoles2D(RectTransform solPositionMin, RectTransform solPositionMax)
    {
        Instantiate(soles2D, gameObject.transform).GetComponent<RectTransform>().anchoredPosition = CalcularPosiSoles(solPositionMin.anchoredPosition, solPositionMax.anchoredPosition);
    }
    public Vector2 CalcularPosiSoles(Vector2 iz, Vector2 der)
    {
        float posiX = Random.Range(iz.x, der.x);
        float posiY = Random.Range(iz.y, der.y);
        Vector2 posifinal = new Vector2(posiX, posiY);
        return posifinal;
    }
    public void AñadirSoles(uint cantidad)
    {
        if (recogidaSol.enabled == false) StartCoroutine(SonidoSol());
        else StartCoroutine(SonidoSolDos());
        solMoneda += cantidad;
    }

    public void EliminarSoles(uint cantidad)
    {
        solMoneda -= cantidad;
    }

    public Vector3 MousePosition()
    {
        return camera2D.ScreenToWorldPoint(Input.mousePosition);
    }

    public IEnumerator FaltanSoles()
    {
        faltaSoles.enabled = true;
        yield return new WaitForSeconds(1);
        faltaSoles.enabled = false;
    }

    public IEnumerator SonidoPlantado()
    {
        sonidoPlantado.enabled = true;
        yield return new WaitForSeconds(1);
        sonidoPlantado.enabled = false;
    }

    public IEnumerator SonidoSol()
    {
        recogidaSol.enabled = true;
        yield return new WaitForSeconds(0.5f);
        recogidaSol.enabled = false;
    }

    public IEnumerator SonidoSolDos()
    {
        recogidaSolDos.enabled = true;
        yield return new WaitForSeconds(0.5f);
        recogidaSolDos.enabled = false;
    }

    public int SpawnZombies(GameObject[]listaZombies)
    {
        int varAleatoria = Random.Range(0,listaZombies.Length);
        return varAleatoria;

    }

    public void CasillaControler(GameObject prefabPlantaPosition,uint costoPlanta)
    {
        foreach (GameObject tem in casiPos)
        {
            if (Vector3.Distance(tem.transform.position, MousePosition()) <= 0.5f && tem.GetComponent<CasillaPosition>().disponible)
            {
                
                StartCoroutine(SonidoPlantado());
                EliminarSoles(costoPlanta);
                GameObject plantaCreada = Instantiate(prefabPlantaPosition);
                if (plantaCreada.GetComponent<LanzaGuizante>())
                {
                    Vector3 tempdos= new Vector3(tem.transform.position.x, tem.transform.position.y + 0.1f, tem.transform.position.z);
                    plantaCreada.transform.position = tempdos;  
                }
                else plantaCreada.transform.position = tem.transform.position;
                tem.GetComponent<CasillaPosition>().platnaSobreMi = plantaCreada;
                plantaCreada.tag = "Planta";
                
            }
        }

    }

    public void CasillaController(GameObject plantaSobreCasilla,CasillaPosition estaCasilla)
    {
        if (plantaSobreCasilla == null)
        {
           estaCasilla.disponible = true;
            Debug.Log("Planta eliminada");
        }
    }
}
