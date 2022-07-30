using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bandera : MonoBehaviour
{
    Animator banderaControl;
    // Start is called before the first frame update
    void Start()
    {
        banderaControl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlzarBandera()
    {
        banderaControl.SetBool("activa", true);
    }
    public void EstaticoArribla()
    {
        banderaControl.SetBool("activa", false);
    }
}
