using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podadora : MonoBehaviour
{
    private bool activo = false, otro = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activo) MoverMorir();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            collision.gameObject.GetComponent<Zombie>().vida = 0;
            collision.gameObject.GetComponent<Zombie>().velocidad = 0;
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
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

}
