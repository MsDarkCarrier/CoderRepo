using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Animator controladorAnim;
    public float vida, dano, velocidad, velociCompro, tiempomax = 0.5f, timpmin, tiemporelentizado = 6f;
    public AudioSource[] comer = new AudioSource[4];
    [SerializeField] GameObject objetoposi, planta;
    public Vector3 posiobjet, direccion;
    private bool comiendo = false;

    void Start()
    {
        controladorAnim = GetComponent<Animator>();
        vida = 200;
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
       if(!GameManager.instancia.pausa) Movimiento();
        else
        {
            
        }
    }
    void Update()
    {
        if(planta==null) controladorAnim.SetBool("Atacar", false);
        if (!GameManager.instancia.pausa)
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
            }
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
        try
        {
            if (other.gameObject.GetComponent<Planta>().enabled && !GameManager.instancia.pausa)
            {
                controladorAnim.SetBool("Atacar", true);
                velocidad = 0;
                planta = other.gameObject;
                Atacando(planta.GetComponent<Planta>(), comer);
                comiendo = true;

            }
        }
        catch (System.Exception)
        {

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
        plant.vida -= dano;
    }

}
