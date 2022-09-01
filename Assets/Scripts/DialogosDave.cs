using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogosDave : MonoBehaviour
{
    private Queue<string> dialogos=new Queue<string>();
    private enum iniciar
    {
        NADA=0
        PREPARADO=1,
        LISTO=2,
        PLANTA=3
    }
    private float max=1f,min=0f,variableTemp=0;
    private iniciar comprobador;
    // Start is called before the first frame update
    void Start()
    {
        ConversionEnum(0);
        dialogos.Enqueue("Buenos Dìas vecino.");
        dialogos.Enqueue("Mi nombre es dave, dave el loco");
        dialogos.Enqueue("¿Què porque uso un sarte en la cabeza?");
        dialogos.Enqueue("!!PORQUE ESTOY LOCO");
        dialogos.Enqueue("A PLANTAR");
        Debug.Log(dialogos.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
       if((int)comprobador!=0)
       {
       } 
    }

    public void ConversionEnum(int face)
    {
        comprobador=(iniciar)face;
    }

    public int ConversionEnum()
    {
        return (int)comprobador;
    }

    public void CargarTextoInicio()
    {
        if(ConversionEnum()==0)
        {

            comprobador=(iniciar)ConversionEnum()++;
        }
    }

    
}
