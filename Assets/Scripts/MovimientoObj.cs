using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObj : MonoBehaviour
{
    public int vida, daño;
    GameObject objetoposi;
    public float velocidad;
    private Vector3 direccion;
    public Vector3 posiobjet;
    private bool activador = true;
    // Start is called before the first frame update
    void Start()
    {
        if (objetoposi == null)
        {
            objetoposi = new GameObject("PosPersonaje");
            objetoposi.transform.position = posiobjet;
            objetoposi.transform.rotation = transform.rotation;
        }

        StartCoroutine(SubirInicioVida());
    }

    // Update is called once per frame
    void Update()
    {
        if (activador) Movimiento();
    }

    IEnumerator Llamadayfinal()
    {
        activador = false;
        Debug.Log("Tan tan tan");
        yield return new WaitForSeconds(2f);
        Debug.Log("¡¡NOOOOOOOOOOO!!");
        yield return new WaitForSeconds(2f);
        Debug.Log("Te han comido los sesos");
        yield return new WaitForSeconds(2f);
        Destroy(objetoposi);
        Destroy(this.gameObject);
        activador = true;
    }
    
    IEnumerator SubirInicioVida()
    {
        activador = false;
        Debug.Log("Subiendo vida");
        for (int x=0; x<100; x++)
        {
            vida += 1;
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Listo para comer cerebros");
        activador = true;
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
            if (activador) StartCoroutine(Llamadayfinal());
        }
    }

    
    public void DañarEnemigo()
    {
        //Aqui dañaria al zombie
    }

    public void Curar()
    {
        //No estoy muy seguro como se impementaría pero sería interezante hehe
    }
    

}
