using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinJuego : MonoBehaviour
{
public void OnTriggerEnter(Collider other) 
{
 
 if(other.GetComponent<Zombie>())
 {
    GameManager.instancia.pausa=true;
    GameObject [] sol2DArray= GameObject.FindGameObjectsWithTag("Soles2D");
    foreach (GameObject soles2D in sol2DArray)
    {
     Destroy(soles2D);
    }
    GameManager.instancia.contenedorJugable.SetActive(false);


 }   
}
}
