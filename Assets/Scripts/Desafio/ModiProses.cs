using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ModiProses : MonoBehaviour
{
    [SerializeField]private PostProcessVolume colorFondo;
    [SerializeField]private ColorGrading colorGreatingProyect;
    // Start is called before the first frame update
    void Start()
    {
        colorFondo = GetComponent<PostProcessVolume>();
       colorFondo.profile.TryGetSettings<ColorGrading>(out colorGreatingProyect);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            colorGreatingProyect.temperature.value = 100;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            colorGreatingProyect.temperature.value = -100;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            colorGreatingProyect.temperature.value = 0;
        }

    }
}
