using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoPlantas : MonoBehaviour
{
    public float daño,velocidad;
    public Vector3 inicio;
    public bool activador = true, otro = false;
    
    // Start is called before the first frame update
    void Start()
    {
        inicio = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var movimiento = Vector3.right * velocidad * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + movimiento.x, transform.position.y, transform.position.z);
        if (!otro) StartCoroutine(TiempoVolver());
    }

    private void OnTriggerEnter(Collider other)
    {

        other.gameObject.GetComponent<Zombie>().vida -= daño;
        VolverBala();
        otro = false;
    }

    public void VolverBala()
    {
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
