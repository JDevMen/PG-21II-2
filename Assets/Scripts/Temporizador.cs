using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    private float tiempo = 60;
    public Text tiempoDisplay;
    public Slider tiempoDisplay2;
    public GameObject menuPausa;
    public float tiempoParaCalcular;

    private int numeroSemana = 0;


    private void Start()
    {
        float tiempoPorSemanas = tiempo / 16;
        Contador();
        StartCoroutine(ContadorSemanas(tiempoPorSemanas));
        tiempoDisplay2.maxValue = tiempo;
        tiempoParaCalcular = tiempo;

        Debug.Log("Tiempo por semana " + tiempoPorSemanas);
    }

    private void Update()
    {
        tiempoDisplay2.value = tiempo;

    }

    public float getTiempo()
    {
        return tiempo;
    }

    IEnumerator ContadorSemanas(float pTiempoPorSemana) {

        while (tiempo>0)
        {
            numeroSemana++;
            tiempoDisplay.text = "Semana " + numeroSemana;

             yield return new WaitForSeconds(pTiempoPorSemana);
        }
    }


    void Contador()
    {
        if (tiempo > 0 && menuPausa.activeSelf == false)
        {
            //TimeSpan spanTime = TimeSpan.FromSeconds(tiempo);
            //if(spanTime.Seconds < 10)
            //{
            //    tiempoDisplay.text = "0" + spanTime.Minutes + ":0" + spanTime.Seconds;
            //}
            //else
            //{
            //    tiempoDisplay.text = "0" + spanTime.Minutes + ":" + spanTime.Seconds;
            //}
            
            tiempo--;
            
        }
        Invoke("Contador", 1.0f);
    }

}
