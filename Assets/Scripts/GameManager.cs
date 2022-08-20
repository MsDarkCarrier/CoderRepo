using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource faltaSoles, sonidoPlantado;
    public static GameManager instancia;
    public Camera camera2D;
    public GameObject soles2D, soles3D;
    public ushort solMoneda, barraProgreso;
    public bool terminar;
    public TextMeshProUGUI texto;
    public ContenedorMundo datosJuego;

    void Start()
    {
        instancia = this;
        texto = GameObject.FindWithTag("SolesText").GetComponent<TextMeshProUGUI>();
        solMoneda = 50;
    }

    void Update()
    {
        texto.text = System.Convert.ToString(solMoneda);
    }

    public void CrearSoles2D(RectTransform solPositionMin, RectTransform solPositionMax)
    {
        Instantiate(soles2D, gameObject.transform).GetComponent<RectTransform>().anchoredPosition= CalcularPosiSoles(solPositionMin.anchoredPosition, solPositionMax.anchoredPosition);
    }
    public Vector2 CalcularPosiSoles(Vector2 iz,Vector2 der)
    {
        float posiX = Random.Range(iz.x, der.x);
        float posiY = Random.Range(iz.y, der.y);
        Vector2 posifinal=new Vector2(posiX,posiY);
        return posifinal;
    }
    public void AñadirSoles(ushort cantidad)
    {
        solMoneda += cantidad;
    }

    public void EliminarSoles(ushort cantidad)
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
}
