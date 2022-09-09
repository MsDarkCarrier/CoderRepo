using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgrecion : MonoBehaviour
{
    public Image progre;
    public RectTransform cabeza;
    public Queue<GameObject> banderas = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        progre = gameObject.GetComponent<Image>();
        GameObject[] temporal = GameObject.FindGameObjectsWithTag("Banderas");
        foreach (GameObject objeto in temporal)
        {
            banderas.Enqueue(objeto);
        }
    }

    public IEnumerator DesencolarElementos()
    {
        banderas.Dequeue().GetComponent<Animator>().SetBool("activa",true);
        GameManager.instancia.hordaZombie.enabled = true;
        yield return new WaitForSeconds(3f);
        GameManager.instancia.hordaZombie.enabled = false;
    }

}
