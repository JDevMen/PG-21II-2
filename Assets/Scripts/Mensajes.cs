using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mensajes : MonoBehaviour
{
    public GameObject letrero;
    public TMP_Text textoLetrero;

    // Start is called before the first frame update
    void Start()
    {
        //textoLetrero = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            lanzarMensaje("Hola, probando, mensaje largo largo laergo largo largo largo");
        }
    }


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
