using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : MonoBehaviour
{
    private float timMin, tiMax=25f;
    public void Start()
    {
        timMin = 0;
    }
    public void Update()
    {
        timMin += Time.deltaTime;
        if (timMin >= tiMax) Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        AgarrarSol();
    }

    public void AgarrarSol()
    {
        GameManager.instancia.solMoneda += 25;
        Destroy(gameObject);
    }

}
