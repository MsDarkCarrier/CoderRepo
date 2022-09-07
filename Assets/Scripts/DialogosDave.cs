using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogosDave : MonoBehaviour
{
    private bool dialogo;
    private float duracion=0;
    [SerializeField] private TextMeshProUGUI textoPreparado,textDialogo;
    private Queue<string> dialogos=new Queue<string>();
    [SerializeField] private GameObject cuadroDialogo,dave,botSaltar;
    [SerializeField] private AudioSource sonidosPam,dialogoMusica;
    [SerializeField]private AudioSource[] daveSon = new AudioSource[11];
    private int varSonido;
    [SerializeField]private bool saltar;
    private enum iniciar
    {
        PREPARADO=0,
        LISTO=1,
        PLANTA=2
    }
    [SerializeField]private float min=0f;
    private iniciar comprobador;
    // Start is called before the first frame update
    void Start()
    {
        saltar=false;
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
    public void BotSaltar()
    {
        min=30;
        saltar=true;
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
                        botSaltar.SetActive(true);
                        duracion= (!saltar)? 1.2f:0;
                        StartCoroutine(AudioDaveControl(daveSon[0], duracion));
                        if(!saltar)min = 0;
                        break;


                    case ("Me llamo dave, dave el loco"):
                        duracion= (!saltar)? 1.5f:0;
                        StartCoroutine(AudioDaveControl(daveSon[1], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("Pero puedes llamarme solo dave el loco"):
                        duracion= (!saltar)? 1.45f:0;
                        StartCoroutine(AudioDaveControl(daveSon[2], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("Bueno venía a decirte una cosita"):
                        duracion= (!saltar)? 1.35f:0;
                        StartCoroutine(AudioDaveControl(daveSon[3], duracion));
                        if(!saltar)min = 0;
                        break;


                    case ("Esta es la primera beta publica del plantas vs zombies en 3D"):
                        duracion= (!saltar)? 2.5f:0;
                        StartCoroutine(AudioDaveControl(daveSon[4], duracion));
                        if(!saltar)min = 0;
                        break;


                    case ("Mal royo"):
                        duracion= (!saltar)? 1.12f:0;
                        StartCoroutine(AudioDaveControl(daveSon[5], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("Puede que este plagado de cosas que no deberían estar allí"):
                        duracion= (!saltar)? 2.5f:0;
                        StartCoroutine(AudioDaveControl(daveSon[6], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("¿Que cosas?"):
                        duracion= (!saltar)? 1.10f:0;
                        StartCoroutine(AudioDaveControl(daveSon[7], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("Quien sabe"):
                        duracion= (!saltar)? 1.10f:0;
                        StartCoroutine(AudioDaveControl(daveSon[8], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("Pero no te preocupes, aquí tienes unos cuantos paquetes de semillas, y esta nuez"):
                        duracion= (!saltar)? 2.5f:0;
                        StartCoroutine(AudioDaveControl(daveSon[9], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("¿Porque te pongo una nuez en la mano?"):
                       duracion= (!saltar)? 1.55f:0;
                        StartCoroutine(AudioDaveControl(daveSon[10], duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("¡¡ PORQUE ESTOY LOCO !!"):
                        duracion= (!saltar)? 2.3f:0;
                        StartCoroutine(AudioDaveControl(daveSon[11],duracion));
                        if(!saltar)min = 0;
                        break;

                    case ("¡¡ A PLANTAR !! "):
                        dialogos.Dequeue();
                        if(!saltar)min = 0;
                        break;

                    case ("¡¡ A PLANTAR !!"):
                        StartCoroutine(AudioDaveControl(daveSon[12], 1.25f));
                        dialogos.Dequeue();
                        if(!saltar)min = 0;
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
