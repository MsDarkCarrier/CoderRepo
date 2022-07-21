using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float vida, daño, velocidad, velociCompro, tiempomax = 0.5f, timpmin, tiemporelentizado = 6f;
    public AudioSource[] comer = new AudioSource[4];
    GameObject objetoposi, planta;
    public Vector3 posiobjet, direccion;
    private bool activador = true, comiendo = false, falserelentizado = false;

    void Start()
    {
        timpmin = 0;
        velociCompro = velocidad;
        if (objetoposi == null)
        {
            objetoposi = new GameObject("PosPersonaje");
            objetoposi.transform.position = new Vector3(-5.50529337f, 0, -7.55999994f);
            objetoposi.transform.rotation = transform.rotation;
        }
        comer[0] = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        Movimiento();
    }
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(objetoposi);
            Destroy(this.gameObject);
        }

        if (comiendo && planta != null)
        {
            timpmin += Time.deltaTime;
            if (timpmin >= tiempomax)
            {
                Atacando(planta.GetComponent<Planta>(), comer);
                timpmin = 0;
            }
        }
        else
        {
            comiendo = false;
            velocidad = velociCompro;
            activador = false;
        }

    }

    public void Movimiento()
    {
        direccion = objetoposi.transform.position - transform.position;
        var movimiento = direccion.normalized * velocidad * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + movimiento.x, transform.position.y, transform.position.z);
        if (Vector3.Distance(transform.position, objetoposi.transform.position) <= 0.1)
        {
            velocidad = 0f;
            transform.position = objetoposi.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Planta>())
        {
            velocidad = 0;
            planta = other.gameObject;
            Atacando(planta.GetComponent<Planta>(), comer);
            comiendo = true;


        }
    }

    void Atacando(Planta plant, AudioSource[] comer)
    {

        int variable = Random.Range(0, 3);
        if (!comer[variable].enabled) comer[variable].enabled = true;
        else if (variable <= 1)
        {
            comer[variable].enabled = false;
            variable++;
            comer[variable].enabled = true;
        }
        else
        {
            comer[variable].enabled = false;
            variable--;
            comer[variable].enabled = true;
        }

        if (plant.vida <= 12.5f && comer[3].enabled)
        {
            comer[3].enabled = true;
        }
        else if (plant.vida <= 100f)
        {
            comer[3].enabled = false;
            comer[3].enabled = true;
        }
        plant.vida -= daño;
    }

    public IEnumerator CongeladoTime()
    {
        velocidad /= 2;
        tiempomax /= 2;
        falserelentizado = false;
        yield return new WaitForSeconds(tiemporelentizado);
        velocidad = 2;
        tiempomax = 2;
        falserelentizado = true;
    }

    /*
     * Linea 1 posiobSjet Vector3(-5f,1.153f,-4.324f)
     * Linea 2 posiobjet Vector3(-5f,1.153f,-5.838f)
     * Linea 3 posiobjet Vector3(-5f,1.153f,-7.256f)
     * Linea 4 pósiobjet Vector3(-5f,1.153f,-8.665f)
     * Linea 5 posiobjet Vector3(-5f,1.153f,-9.94f)
     * ESTAS SON LAS POSISIONES FINALES DEL OBJETIVO DE CADA LINEA
     * Linea 1 posiobjet Vector3(5f,1.153f,-4.324f)
     * Linea 2 posiobjet Vector3(5f,1.153f,-5.838f)
     * Linea 3 posiobjet Vector3(5f,1.153f,-7.256f)
     * Linea 4 pósiobjet Vector3(5f,1.153f,-8.665f)
     * Linea 5 posiobjet Vector3(5f,1.153f,-9.94f)
     * SPAWN POSISIONES CADA FILA ZOMBIES
     */

}
