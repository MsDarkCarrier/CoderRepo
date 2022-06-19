using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta : MonoBehaviour
{
    public GameObject balaPlanta, mira, reto;
    private bool activ = true;
    // Start is called before the first frame update
    void Start()
    {
        balaPlanta = Instantiate(balaPlanta);
        balaPlanta.transform.position = mira.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!balaPlanta.GetComponent<DanoPlantas>().activador) StartCoroutine(DisparoTiempo());
        //DispararRaro();
    }
    IEnumerator DisparoTiempo()
    {
        yield return new WaitForSeconds(1.5f);
        balaPlanta.SetActive(true);
        balaPlanta.GetComponent<DanoPlantas>().activador = true;
    }
    /*
     * DESAFÍO COMPLEMENTARIO
    void DispararRaro()
    {
        //No se adecua al tipo de juego que tengo, ya que es un RTS tipo PVZ, pero espero que puedan aceptar como parte el desafio descomentar ploxs >.<

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) && activ)
        {
            StartCoroutine(Bang());
        }
    }
    IEnumerator Bang()
    {
        activ = false;
        Debug.Log("BANG BANG!!");
        GameObject objetos=Instantiate(reto);
        StartCoroutine(BorrarBala(objetos));
        yield return new WaitForSeconds(0.5f);
        activ = true;
    }

    IEnumerator BorrarBala(GameObject balaBorrar)
    {
        yield return new WaitForSeconds(5f);
        Destroy(balaBorrar);
    }
    */

}
