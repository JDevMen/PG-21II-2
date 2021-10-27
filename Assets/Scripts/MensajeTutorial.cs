using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MensajeTutorial : MonoBehaviour
{
    public GameObject letrero;
    public TMP_Text textoLetrero;


    public void lanzarMensaje(string mensaje)
    {

        textoLetrero.text = mensaje;
        letrero.SetActive(true);
        Time.timeScale = 0f;
    }

    public void cerrarMensaje()
    {
        letrero.SetActive(false);
        Time.timeScale = 1f;
    }
}
