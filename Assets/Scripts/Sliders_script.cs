using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders_script : MonoBehaviour
{
    //Sliders de puntuaci�n jugador
    public Slider energia;
    public Slider universidad;
    public Slider familia;
    public int puntajeMax;

    private paddle_script jugadorScript;

    //puntos del jugador
    private float puntosEnergia;
    private float puntosUniversidad;
    private float puntosFamilia;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        energia.maxValue = puntajeMax;
        universidad.maxValue = puntajeMax;
        familia.maxValue = puntajeMax;

        if (player != null)
        {
            jugadorScript = player.GetComponent<paddle_script>();
            Debug.Log("Se encontr� y asign� script de control del jugador.");
            Debug.Log("-------------------------------");

            puntosEnergia = jugadorScript.getPuntosEnergia();
            puntosUniversidad = jugadorScript.getPuntosUniversidad();
            puntosFamilia = jugadorScript.getPuntosFamilia();

            //Revisi�n de carga de puntos jugador
            Debug.Log("Puntos de energia: " + puntosEnergia);
            Debug.Log("Puntos de universidad: " + puntosUniversidad);
            Debug.Log("Puntos de familia: " + puntosFamilia);

            //Asignaci�n de sliders a puntos del jugador
            energia.value = jugadorScript.puntosEnergia;
            universidad.value = jugadorScript.puntosUniversidad;
            familia.value = jugadorScript.puntosFamilia;

            
        }
        else Debug.Log("No se encontr� ning�n jugador en la escena");
    }

    private void Update()
    {
        if (jugadorScript != null)
        {
            energia.value = jugadorScript.puntosEnergia;
            universidad.value = jugadorScript.puntosUniversidad;
            familia.value = jugadorScript.puntosFamilia;
        }
    }

}
