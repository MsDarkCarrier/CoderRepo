using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sol : MonoBehaviour
{
    private float timMin, tiMax = 25f;
    public UnityEvent<uint> recogidaSol;
    public void Start()
    {
        timMin = 0;
        try
        {
            recogidaSol.AddListener(GameManager.instancia.AñadirSoles);
        }
        catch (System.Exception) 
        { 
        }
        
    }
    public void Update()
    {
        timMin += Time.deltaTime;
        if (timMin >= tiMax) Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (recogidaSol != null)
        {
            GameManager.instancia.AñadirSoles(25);
            Destroy(gameObject);
        }
    }

    public void Sol2Dcontroller()
    {
        if (recogidaSol != null)
        {
            recogidaSol.Invoke(25);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        recogidaSol.RemoveListener(GameManager.instancia.AñadirSoles);
    }

}
