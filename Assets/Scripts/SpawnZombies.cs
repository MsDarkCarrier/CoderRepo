using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnZombies : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnZombies = new GameObject[5];
    UnityEvent llamadaZombie;
    public int cantidadZombies;
    // Start is called before the first frame update
    void Start()
    {
        spawnZombies = GameObject.FindGameObjectsWithTag("SpawnZombies");
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
