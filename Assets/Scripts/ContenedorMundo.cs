using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MundoInfo",menuName ="ScriptableObjets/InformacionMundo",order =1)]
public class ContenedorMundo : ScriptableObject
{
    public uint nivel=0;
    public string nombreJugador;
}
