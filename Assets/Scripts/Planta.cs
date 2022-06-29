using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planta : MonoBehaviour
{
    private int tp = 0;
    private float tiempoMin = 0, tiempoMax = 3f;
    public string tipGuisante;
    public GameObject balaPlanta, mira;
    private GameObject[] balas;
    public bool zombie;
    public float vida;

    void Start()
    {
        TipoPlanta();
        for (int x = 0; x < balas.Length; x++)
        {
            if (tipGuisante=="e") balas[x].GetComponent<Guisantes>().hielo = true;
            balas[x] = Disparador();
            balas[x].name = "Guisante" + x;
            balas[x].GetComponent<Guisantes>().inicio = mira.transform.position;
            balas[x].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            for (int x = 0; x < balas.Length; x++)
            {
                if (!balas[x].activeInHierarchy) Destroy(balas[x]); else balas[x].GetComponent<Guisantes>().inicio = new Vector3(0, 0, 0);
            }
            Destroy(this.gameObject);
        }
        if (zombie)
        {
            tiempoMin += Time.deltaTime;
            if (tiempoMin >= tiempoMax)
            {
                StartCoroutine(TiempoMicro());
                tiempoMin = 0;
            }
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
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }
                    if (tp == 1)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
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
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }
                    if (tp == 1)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }

                    if (tp == 2)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
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
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }
                    if (tp == 1)
                    {
                        yield return new WaitForSeconds(0.1f);
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }

                    if (tp == 2)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
                        balas[x].SetActive(true);
                        tp++;
                        continue;
                    }

                    if (tp == 3)
                    {
                        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                        balas[x].SetActive(true);
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

    /*Guisante normal=a
     * Repartidora=b
     * Tripitidora=c
     * Guisantalladora=d
     */
}
