using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaGuizante : MonoBehaviour
{
    private int tp = 0,contador;
    private float tiempoMin = 0, tiempoMax;
    public string tipGuisante;
    public GameObject balaPlanta, mira;
    private GameObject[] balas;
    [SerializeField]private bool zombie, primeraVez = true;
    public AudioSource salidaDos, salida;

    private void Awake()
    {
        contador = 0;
    }
    void Start()
    {
        TipoPlanta();
        for (int x = 0; x < balas.Length; x++)
        {
            if (tipGuisante == "e") balas[x].GetComponent<Guisante>().hielo = true;
            balas[x] = Disparador();
            balas[x].name = "Guisante" + x;
            balas[x].GetComponent<Guisante>().inicio = mira.transform.position;
            balas[x].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Planta>().vida <= 0)
        {
            for (int x = 0; x < balas.Length; x++)
            {
                if (!balas[x].activeInHierarchy) Destroy(balas[x]); else balas[x].GetComponent<Guisante>().inicio = new Vector3(0, 0, 0);
            }
            Destroy(this.gameObject);
        }
        DetectorZombie();
        if (zombie)
        {
            tiempoMax = Random.Range(1,1.9f);
            if (primeraVez)
            {
                primeraVez = false;
                StartCoroutine(TiempoMicro());
            }
            tiempoMin += Time.deltaTime;
            if (tiempoMin >= tiempoMax)
            {
                StartCoroutine(TiempoMicro());
                tiempoMin = 0;
            }
        }
    }

    private void SonidoDisparo()
    {
        if (contador <= 0)
        {
            contador++;
            salida.enabled = true;
            if (salidaDos.enabled) salidaDos.enabled = false;
        }
        else
        {
            contador--;
            if (salida.enabled) salida.enabled = false;
            salidaDos.enabled = true;
        }
    }
    IEnumerator TiempoMicro()
    {
        for (int x = 0; x < balas.Length; x++)
        {
            if (tipGuisante == "a")
            {
                if (!balas[x].activeInHierarchy)
                {
                    SonidoDisparo();
                    balas[x].SetActive(true);
                    break;
                }
            }
            if (tipGuisante == "b")
            {
                if (!balas[x].activeInHierarchy)
                {
                    if (tp == 0)
                    {
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }
                    if (tp == 1)
                    {
                        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        tp = 0;
                        break;
                    }
                }
            }

            if (tipGuisante == "c")
            {
                if (!balas[x].activeInHierarchy)
                {
                    if (tp == 0)
                    {
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }
                    if (tp == 1)
                    {
                        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }

                    if (tp == 2)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        tp = 0;
                        break;
                    }
                }
            }

            if (tipGuisante == "d")
            {
                if (!balas[x].activeInHierarchy)
                {
                    if (tp == 0)
                    {
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        balas[x].GetComponent<Guisante>().hielo = true;
                        tp++;
                        continue;
                    }
                    if (tp == 1)
                    {
                        yield return new WaitForSeconds(0.1f);
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        balas[x].GetComponent<Guisante>().hielo = true;
                        tp++;
                        continue;
                    }

                    if (tp == 2)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        balas[x].GetComponent<Guisante>().hielo = true;
                        tp++;
                        continue;
                    }

                    if (tp == 3)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                        SonidoDisparo();
                        balas[x].SetActive(true);
                        balas[x].GetComponent<Guisante>().hielo = true;
                        tp = 0;
                        break;
                    }
                }
            }



        }
    }
    GameObject Disparador()
    {
        GameObject guisante;
        guisante = Instantiate(balaPlanta);
        guisante.transform.position = mira.transform.position;
        return guisante;
    }
    void TipoPlanta()
    {
        switch (tipGuisante)
        {
            case ("a"):
                GameObject[] guisan = new GameObject[3];
                balas = guisan;
                break;

            case ("b"):
                GameObject[] rep = new GameObject[5];
                balas = rep;
                break;

            case ("c"):
                GameObject[] trip = new GameObject[7];
                balas = trip;
                break;
            case ("d"):
                GameObject[] tralla = new GameObject[9];
                balas = tralla;
                break;
            default:
                GameObject[] hielo = new GameObject[3];
                balas = hielo;
                break;
        }
    }

    void DetectorZombie()
    {
        RaycastHit recibe;
        if (Physics.Raycast(mira.transform.position, Vector3.right, out recibe, 7.2f, LayerMask.GetMask("Zombie")))
        {
            zombie = true;
        }
        else
        {
            primeraVez = true;
            zombie = false;
        }
    }

    /*Guisante normal=a
     * Repartidora=b
     * Tripitidora=c
     * Guisantalladora=d
     */
}
