using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : MonoBehaviour
{
    public GameObject sol;
    public void Start()
    {
        sol = gameObject;
    }

    private void OnMouseDown()
    {
        GameManager.instancia.SolMoneda += 25;
        Destroy(gameObject);

    }

}
