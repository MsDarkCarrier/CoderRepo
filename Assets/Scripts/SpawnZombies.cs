using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnZombies : MonoBehaviour
{
    [SerializeField] private Transform[] spawnZombies = new Transform[5];
    [SerializeField]private BarraProgrecion barraprogre;
    public GameObject prefabZombie;
    [SerializeField] private float min, max=370;
    int enteroMin;
    void Update()
    {
        if (!GameManager.instancia.pausa && GameManager.instancia.contenedorJugable.activeInHierarchy)
        {
            min +=Time.deltaTime;
            enteroMin = System.Convert.ToInt32(min);
            switch (enteroMin)
            {
                case (30):
                    //primer zombie 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (59):
                    //segundo zombie 1  
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (73):
                    //Tercer zombie 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (85):
                    //Fila de dos zombies 2
                    SpawnearZombies(2, prefabZombie);
                    break;
                case (110):
                    //Fila de tres zombies 3
                    SpawnearZombies(3, prefabZombie);
                    break;
                case (120):
                    //Fila de dos zombies en lugares aleatorios 2
                    SpawnearZombies(2, prefabZombie);
                    break;
                case (128):
                    //zombie en linea aleatoria 1
                    SpawnearZombies(1, prefabZombie);

                    break;
                case (138):
                    //zombie doble en diferentes lineas 2 
                    SpawnearZombies(2, prefabZombie);
                    break;
                case (150):
                    //cuadro zombies en diferentes lineas 4
                    SpawnearZombies(4, prefabZombie);
                    break;
                case (176):
                    //zombie doble en la misma linea 2
                    SpawnearZombies(2, prefabZombie);
                    break;
                case (181):
                    //zombie triple, dos en la misma linea 3
                    SpawnearZombies(3, prefabZombie);
                    break;
                case (198):
                    //zombie en linea aleatoria 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (210):
                    //Primera bandera bandera seis zombies en diferentes lineas 6 
                    SpawnearZombies(6, prefabZombie);
                    StartCoroutine(barraprogre.DesencolarElementos());
                    break;
                case (220):
                    // zombie 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                //Total de zombies = 30
                case (228):
                    //ultimo zombie 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (240):
                    //ultimo zombie 2
                    SpawnearZombies(2, prefabZombie);
                    break;
                case (245):
                    //ultimo zombie 4
                    SpawnearZombies(4, prefabZombie);
                    break;
                case (255):
                    //ultimo zombie 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (262):
                    //ultimo zombie 5
                    SpawnearZombies(5, prefabZombie);
                    break;
                case (272):
                    //ultimo zombie 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (289):
                    //ultimo zombie 3
                    SpawnearZombies(3, prefabZombie);
                    break;
                case (295):
                    //ultimo zombie 4
                    SpawnearZombies(4, prefabZombie);
                    break;
                case (298):
                    //ultimo zombie 2
                    SpawnearZombies(2, prefabZombie);
                    break;
                case (310):
                    //ultimo zombie 2
                    SpawnearZombies(2, prefabZombie);
                    break;
                case (319):
                    //ultimo zombie 1
                    SpawnearZombies(1, prefabZombie);
                    break;
                case (325):
                    //ultimo zombie 10 bandera final
                    SpawnearZombies(10, prefabZombie);
                    StartCoroutine(barraprogre.DesencolarElementos());
                    break;
                    //Total de zombies 66
            }
            if (enteroMin >= 355&& GameObject.FindGameObjectsWithTag("Zombie").Length==0)
            {
                GameManager.instancia.pausa = true;
                GameManager.instancia.ganaste = true;
            }
        }
    }

    public void SpawnearZombies(int numeroZombies, GameObject prefab)
    {
        if (numeroZombies > 1)
        {
            for (int x=0; x<=numeroZombies; x++)
            {
                int temporal = Random.Range(0, 5);
                Instantiate(prefabZombie, spawnZombies[temporal]);
            }
            barraprogre.progre.fillAmount += CalculoPorcentajeZombie(numeroZombies);
            min++;
        }
        else
        {
            
            int temporal = Random.Range(0, 5);
            Instantiate(prefabZombie, spawnZombies[temporal]);
            min++;
            barraprogre.progre.fillAmount += 0.0167f;
        }
    }
    public float CalculoPorcentajeZombie(int numZombies)
    {
        float porcentajeBarra = 0.0167f*numZombies;
        return porcentajeBarra;
    }
}
