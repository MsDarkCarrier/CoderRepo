using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegreMen : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
