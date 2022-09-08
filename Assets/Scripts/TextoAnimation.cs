using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoAnimation : MonoBehaviour
{
    private Animator animacionSalida;
    private void Awake()
    {
        animacionSalida = GetComponent<Animator>();
    }

    public void PasarVar()
    {
        animacionSalida.SetBool("Comer", true);
    }
}
