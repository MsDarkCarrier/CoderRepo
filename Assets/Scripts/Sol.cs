using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : MonoBehaviour
{
    public GameObject sol;
    private float timMin, tiMax=20f;
    public void Start()
    {
        timMin = 0;
        sol = gameObject;
    }
    public void Update()
    {
        timMin += Time.deltaTime;
        if (timMin >= tiMax) Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        GameManager.instancia.solMoneda += 25;
        Destroy(gameObject);

    }

}
