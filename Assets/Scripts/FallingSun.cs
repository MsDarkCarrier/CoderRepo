using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSun : MonoBehaviour
{
    [SerializeField]private Canvas canvas;
    private RectTransform rt;
    public GameObject SolPrefab2D;
    public float momentoCaida;
    public Transform lugarCaida;
    public float tiempoSolSpawn;
    public List<Transform> tr = new List<Transform>();

    private void Start()
    {
        rt = canvas.GetComponent<RectTransform>();
        momentoCaida = Random.Range(5, 15);
        lugarCaida = tr[Random.Range(1, 5)];
    }

    private void Spawneo()
    {
        tiempoSolSpawn += Time.deltaTime;
        if (tiempoSolSpawn >= momentoCaida)
        {
            Instantiate(SolPrefab2D, lugarCaida);
            momentoCaida = Random.Range(5, 15);
            tiempoSolSpawn = 0;
            lugarCaida = tr[Random.Range(1, 5)];
        }   
    }
    

    private void Update()
    {
        Spawneo();

    }
}
