using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField]private AudioSource finalMusic;
    [SerializeField] private AudioSource grito;
    bool perder,detonador;
    private void Start()
    {
        finalMusic = GetComponent<AudioSource>();
        perder = false;
    }
    private void Update()
    {
        if (!finalMusic.isPlaying && detonador) perder = true;
        if (perder) StartCoroutine(TiempoRegreso());
        
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Zombie>())
        {
            GameManager.instancia.musicaAmbiente.enabled = false;
            GameManager.instancia.pausa = true;
            GameObject[] sol2DArray = GameObject.FindGameObjectsWithTag("Soles2D");
            foreach (GameObject soles2D in sol2DArray)
            {
                Destroy(soles2D);
            }
            GameManager.instancia.contenedorJugable.SetActive(false);
            panelGameOver.SetActive(true);
            finalMusic.enabled = true;
            detonador = true;
        }
    }

    IEnumerator TiempoRegreso()
    {
        perder = false;
        grito.enabled = true;
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }


}
