using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podadora : MonoBehaviour
{
    private bool activo = false, otro = false;
    private AudioSource salida;

    void Start()
    {
        salida = gameObject.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (activo&&!GameManager.instancia.pausa) MoverMorir();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Zombie"))
        {
            salida.enabled = true;
            other.gameObject.GetComponent<Zombie>().vida = 0;
            other.gameObject.GetComponent<Zombie>().velocidad = 0;
            activo = true;
        }
        


    }
    public void MoverMorir()
    {
        var movimiento = Vector3.right * 2f * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + movimiento.x, transform.position.y, transform.position.z);
        if (!otro) StartCoroutine(PodadoraMorirTime());
    }

    IEnumerator PodadoraMorirTime()
    {
        otro = true;
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

}
