using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Planta))]
public class Nuez : MonoBehaviour
{
    
    void Update()
    {
        if (gameObject.GetComponent<Planta>().vida <= 0) Destroy(gameObject);
    }
}
