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

        energia.maxValue = 10;
        energia.value= 10;
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
            //energia.value = jugadorScript.puntosEnergia;
            universidad.value = jugadorScript.puntosUniversidad;
            familia.value = jugadorScript.puntosFamilia;


            
        }
        else Debug.Log("No se encontr� ning�n jugador en la escena");
    }

    private void FixedUpdate()
    {
        if (jugadorScript != null)
        {
            energia.value-=0.008f*Time.timeScale;
            Debug.Log("eneergia.value es "+energia.value);
            energia.value += jugadorScript.puntosEnergia*2;
            universidad.value = jugadorScript.puntosUniversidad;
            jugadorScript.puntosEnergia = 0;
            familia.value = jugadorScript.puntosFamilia;
            if(energia.value==0){
                energia.value=10;

                StartCoroutine(jugadorScript.Dormir());

            }
        }
    }

}
