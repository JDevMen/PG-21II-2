using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public int tiempo = 5;
    public Text tiempoDisplay;
    public Slider tiempoDisplay2;
    public GameObject menuPausa;

    private void Start()
    {
        Contador();
        tiempoDisplay2.maxValue = tiempo;
    }

    private void Update()
    {
        tiempoDisplay2.value = tiempo;

        //if(tiempo == 0)
        //{
        //    SceneManager.LoadScene("Menu");
        //}
    }

    public int getTiempo()
    {
        return tiempo;
    }

    void Contador()
    {
        if (tiempo > 0 && menuPausa.activeSelf == false)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(tiempo);
            if(spanTime.Seconds < 10)
            {
                tiempoDisplay.text = "0" + spanTime.Minutes + ":0" + spanTime.Seconds;
            }
            else
            {
                tiempoDisplay.text = "0" + spanTime.Minutes + ":" + spanTime.Seconds;
            }
            
            tiempo--;
            
        }
        Invoke("Contador", 1.0f);
    }

}
