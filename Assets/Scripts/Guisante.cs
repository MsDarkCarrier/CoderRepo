using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guisante : MonoBehaviour
{
    public float daño,velocidad,tiempoMin,tiempoMax;
    public Vector3 inicio;
    public bool activador = true, otro = false,hielo=false;
    public AudioSource[] sonidosSplash=new AudioSource[3];
    private uint contador;

    private void Awake()
    {
        contador = 0;
        sonidosSplash[0] = GetComponent<AudioSource>();
        
    }

    private void FixedUpdate()
    {
        var movimiento = Vector3.right * velocidad * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + movimiento.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame CAMBIANDO COSITAS
    void Update()
    {
        if (!otro) StartCoroutine(TiempoVolver());
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<Zombie>())
        {
            other.gameObject.GetComponent<Zombie>().vida -= daño;
            VolverBala();
            otro = false;
        }
        
    }

    public void VolverBala()
    {
        if (inicio== new Vector3(0,0,0)) Destroy(this.gameObject);
        foreach (AudioSource desacSon in sonidosSplash)
        {
            desacSon.enabled = false;
        }
        this.gameObject.SetActive(false);
        transform.position = inicio;
        activador = false;
    }

    public IEnumerator TiempoVolver()
    {
        otro = true;
        yield return new WaitForSeconds(5f);
        VolverBala();
        otro = false;
    }






}
