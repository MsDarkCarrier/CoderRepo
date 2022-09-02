using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogosDave : MonoBehaviour
{
    bool dialogo;
    [SerializeField] private TextMeshProUGUI textoPreparado,textDialogo;
    private Queue<string> dialogos=new Queue<string>();
    [SerializeField] private GameObject cuadroDialogo,dave;
    [SerializeField] private AudioSource sonidosPam,dialogoMusica;
    [SerializeField]private AudioSource[] daveSon = new AudioSource[11];
    private int varSonido;
    private enum iniciar
    {
        PREPARADO=0,
        LISTO=1,
        PLANTA=2
    }
    private float min=0f;
    private iniciar comprobador;
    // Start is called before the first frame update
    void Start()
    {
        dialogo = true;
        textoPreparado.enabled = true;
        ConversionEnum(0);
        dialogos.Enqueue("Buenos Dìas vecino");
        dialogos.Enqueue("Me llamo dave, dave el loco");
        dialogos.Enqueue("Pero puedes llamarme solo dave el loco");
        dialogos.Enqueue("Bueno venía a decirte una cosita");
        dialogos.Enqueue("Esta es la primera beta publica del plantas vs zombies en 3D");
        dialogos.Enqueue("Mal royo");
        dialogos.Enqueue("Puede que este plagado de cosas que no deberían estar allí");
        dialogos.Enqueue("¿Que cosas?");
        dialogos.Enqueue("Quien sabe");
        dialogos.Enqueue("Pero no te preocupes, aquí tienes unos cuantos paquetes de semillas, y esta nuez");
        dialogos.Enqueue("¿Porque te pongo una nuez en la mano?");
        dialogos.Enqueue("¡¡ PORQUE ESTOY LOCO !!");
        dialogos.Enqueue("¡¡ A PLANTAR !!");
        dialogos.Enqueue("¡¡ A PLANTAR !! ");

    }

    // Update is called once per frame
    void Update()
    {
        min += Time.deltaTime;
        if(dialogos!=null&&dialogo) DesencolarDave();
        if ((int)comprobador <= 2 && textoPreparado.gameObject.activeInHierarchy)
        {
            if (min >= 1f && (int)comprobador != 3)
            {
                if (!sonidosPam.enabled) sonidosPam.enabled = true;
                textoPreparado.text = System.Convert.ToString(comprobador);
                comprobador = (iniciar)comprobador + 1;
                min = 0;
            }
        }
        else if ((int)comprobador >= 3)
            if (min >= 1.5)
            {
                Destroy(textoPreparado);
                GameManager.instancia.musicaAmbiente.enabled = true;
                GameManager.instancia.contenedorJugable.SetActive(true);
                Destroy(GetComponent<DialogosDave>());
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

    public IEnumerator AudioDaveControl(AudioSource activar,float duracion)
    {
        dialogo = false;
        activar.enabled = true;
        yield return new WaitForSeconds(duracion);
        activar.enabled = false;
        dialogo = true;
    }

    public void DesencolarDave()
    {
        if (Input.GetMouseButtonDown(0)||min>=30 ||Input.GetKeyDown(KeyCode.Space))
        {
            try
            {
                textDialogo.text = dialogos.Dequeue();

                switch (textDialogo.text)
                {

                    case ("Buenos Dìas vecino"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[0], 1.12f));
                        break;


                    case ("Me llamo dave, dave el loco"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[1], 1.50f));
                        break;

                    case ("Pero puedes llamarme solo dave el loco"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[2], 1.45f));
                        break;

                    case ("Bueno venía a decirte una cosita"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[3], 1.35f));
                        break;


                    case ("Esta es la primera beta publica del plantas vs zombies en 3D"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[4], 2.5f));
                        break;


                    case ("Mal royo"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[5], 1.12f));
                        break;

                    case ("Puede que este plagado de cosas que no deberían estar allí"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[6], 2.5f));
                        break;

                    case ("¿Que cosas?"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[7], 1.10f));
                        break;

                    case ("Quien sabe"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[8], 1.10f));
                        break;

                    case ("Pero no te preocupes, aquí tienes unos cuantos paquetes de semillas, y esta nuez"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[9], 2.5f));
                        break;

                    case ("¿Porque te pongo una nuez en la mano?"):
                        cuadroDialogo.SetActive(true);
                        StartCoroutine(AudioDaveControl(daveSon[10], 1.55f));
                        break;

                    case ("¡¡ PORQUE ESTOY LOCO !!"):
                        StartCoroutine(AudioDaveControl(daveSon[11], 2.3f));
                        break;

                    case ("¡¡ A PLANTAR !! "):
                        dialogos.Dequeue();
                        break;

                    case ("¡¡ A PLANTAR !!"):
                        StartCoroutine(AudioDaveControl(daveSon[12], 1.25f));
                        dialogos.Dequeue();
                        break;

                }

            }
            catch (System.Exception)
            {
                dialogos = null;
                Destroy(dave); 
                textoPreparado.gameObject.SetActive(true);
                min = 0;
            }
            
        }
    }

    
}
