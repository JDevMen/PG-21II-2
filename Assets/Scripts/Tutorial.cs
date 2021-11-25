using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Tutorial : MonoBehaviour
{

    public GameObject UICanvas;
    public GameObject panelOscuro;
    public GameObject panelJugador;
    Animator panelJugadorAnimator;
    public GameObject panelBarras;
    public GameObject panelPelotas;
    public GameObject panelEvento;
    public GameObject panelTiempo;
    public GameObject pelotaRoja;
    public GameObject pelotaVerde;
    public GameObject pelotaAmarilla;
    public GameObject pelotaEvento;
    public GameObject mensaje;
    public GameObject botonPausa;

    public TMP_Text textoBoton;

    public MensajeTutorial mensajeria;





    // Start is called before the first frame update
    void Start()
    {
        
        panelOscuro = GameObject.FindGameObjectWithTag("pOscuro");

        if(panelOscuro != null)
        {
            if (panelOscuro.activeSelf == true)
            {
                Time.timeScale = 0f;
                mensajeria = UICanvas.GetComponent<MensajeTutorial>();
                mensaje.SetActive(true);
                botonPausa.SetActive(false);
                panelJugador.SetActive(true);
                panelJugadorAnimator = panelJugador.GetComponent<Animator>();
                panelJugadorAnimator.Play("upAndDown");
                 
                mensajeria.lanzarMensaje("Este es el jugador");
            }
        }
        

    }


    


    public void transicionTutorial()
    {
        if (panelJugador.activeSelf == true)
        {
            panelJugadorAnimator.Play("Exit");
            panelJugador.SetActive(false);
            panelBarras.SetActive(true);
            mensajeria.lanzarMensaje("Estas barras indican los puntos de cada uno de los aspectos de tu vida");
        }
        else if (panelBarras.activeSelf == true)
        {
            panelBarras.SetActive(false);
            panelTiempo.SetActive(true);
            mensajeria.lanzarMensaje("Esta barra representa el avance del semestre. La duración de este es de 16 semanas.");

            textoBoton.text = "Volver al menú";
        }
        else if (panelTiempo.activeSelf == true)
        {
            panelEvento.SetActive(false);
            pelotaEvento.SetActive(false);



            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
            

    }
}
