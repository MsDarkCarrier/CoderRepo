using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createzombie : MonoBehaviour
{
    public GameObject prefabZombie;
    private float tiMin, tiMax;
    private uint contadorVeces = 0;
    private bool comprobador,coolDawn;
    // Start is called before the first frame update
    void Start()
    {
        tiMin = 0;
        tiMax = 3f;
        comprobador = false;
        coolDawn = false;
    }

    private void Update()
    {
        if (comprobador && !coolDawn)
        {
            contadorVeces++;
            Instantiate(prefabZombie).transform.position=transform.position;
            comprobador = false;
            coolDawn = true;
        }
        else if (comprobador && coolDawn)
        {
            tiMin += Time.deltaTime;
            contadorVeces++;
            if (tiMin >= tiMax&&contadorVeces<=1)
            {
                Instantiate(prefabZombie).transform.position = transform.position;
                coolDawn = false;
                comprobador = false;
            }
            else if(tiMin >= tiMax)
            {
                coolDawn = false;
                comprobador = false;
            }
        }


    }
    public void CrearZombieBot()
    {
        comprobador = true;
    }

}
