using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public int tiempo = 20;
    public Text tiempoDisplay;
    public GameObject menuPausa;

    private void Start()
    {
        Contador();
    }

    private void Update()
    {
        
        if(tiempo == 0)
        {
            SceneManager.LoadScene("Menu");
        }
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
