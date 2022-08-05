using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSun : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform rt;
    public GameObject SolPrefab;
    public float momentoCaida;
    public Transform lugarCaida;
    public float tiempo;

    public List<Transform> tr = new List<Transform>();

    void Start()
    {
        rt = canvas.GetComponent<RectTransform>();
        momentoCaida = Random.Range(5, 15);
        lugarCaida = tr[Random.Range(1, 5)];
    }

    private void Spawneo()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= momentoCaida)
        {
            Instantiate(SolPrefab, lugarCaida);
            momentoCaida = Random.Range(5, 15);
            tiempo = 0;
            lugarCaida = tr[Random.Range(1, 5)];
        }   
    }
    

    void Update()
    {
        Spawneo();

    }
}
