using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public Text tiempoDisplay;
    public Slider tiempoDisplay2;
    public GameObject menuPausa;
    private float tiempoPartida = 60;
    public float tiempoParaCalcular;
    private float tiempoMaxPartida;

    private int numeroSemana = 0;


    private void Start()
    {
        tiempoMaxPartida = tiempoPartida;
        tiempoParaCalcular = tiempoPartida;
        float tiempoPorSemanas = tiempoMaxPartida / 16;
        tiempoPartida = 0;
        Contador();
        StartCoroutine(ContadorSemanas(tiempoPorSemanas));
        tiempoDisplay2.maxValue = tiempoMaxPartida;

        Debug.Log("Tiempo por semana " + tiempoPorSemanas);
    }

    private void Update()
    {
        tiempoDisplay2.value = tiempoPartida;

    }

    public float getTiempo()
    {
        return tiempoPartida;
    }

    IEnumerator ContadorSemanas(float pTiempoPorSemana) {

        while (tiempoPartida < tiempoMaxPartida)
        {
            numeroSemana++;
            tiempoDisplay.text = "Semana " + numeroSemana;

             yield return new WaitForSeconds(pTiempoPorSemana);
        }
    }


    void Contador()
    {
        if (tiempoPartida < tiempoMaxPartida && menuPausa.activeSelf == false)
        {
            tiempoPartida++;
            
        }
        Invoke("Contador", 1.0f);
    }

}
