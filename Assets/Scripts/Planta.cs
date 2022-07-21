using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planta : MonoBehaviour
{

    public float vida;
    public float coste;
    public enum VelocidadRecarga
    {
        Rapida=8,
        Lenta=30,
        MuyLenta=50
    }
    public VelocidadRecarga _recarga = VelocidadRecarga.Rapida;

    public void SistemaRecarga()
    {
        switch (_recarga)
        {
            case VelocidadRecarga.Rapida:
                
                break;
            case VelocidadRecarga.Lenta:
                
                break;
            case VelocidadRecarga.MuyLenta:
                
                break;
        }
    }

}
