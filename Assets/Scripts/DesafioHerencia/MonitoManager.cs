using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoManager : MonoBehaviour
{
    protected int vida;
    protected int daño;
    protected int armaduraExtra;
    protected float timpMin, tiemMax = 5, velocidad=0.2f;
    protected Vector3 direccion;
    protected bool enemigo,caminar;
    protected float distanciaEnemi;
    private Vector3 mira;
    // Start is called before the first frame update
    private void Start()
    {
        caminar = false;
        velocidad = 0.2f;
        mira = transform.position;
        vida = 100;
        daño = 5;
        armaduraExtra = 50;
        enemigo = false;
    }

    protected void Atacando()
    {
       Debug.Log("Estoy atacando con: " + daño + " de daño al enemigo");
    }

    protected void Caminar()
    {
        if (caminar)
        {
            Vector3 direccionNormal = direccion - transform.position;
            Vector3 movimiento = direccionNormal.normalized * velocidad * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + movimiento.x, transform.position.y, transform.position.z);
        }
    }

    protected bool DetectarEnemigo()
    {
        bool enemigo = false;
        
        RaycastHit recibe;
        if (Physics.Raycast(transform.position, -Vector3.right, out recibe, 5f, LayerMask.GetMask("MonitoEnemi"))) 
        {
            enemigo = true;
            direccion = recibe.transform.position;
            distanciaEnemi = recibe.distance;
        }
        else
        {
            enemigo = false;
        }
        return enemigo;
    }
}
