using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CargaEscenarios : MonoBehaviour
{

    public GameObject esce1;
    public TMP_Text txtPuntaje;
    public GameObject esce2;
    public GameObject esce3;
    public GameObject esce4;

    public bool verCalculo = false; 

    public TMP_Text textoBoton;

    int escenario = EvaluacionPuntaje.escenarioCargar;

    float puntosEnergiaFinal = EvaluacionPuntaje.puntosEnergiaFinal;
    float puntosUniversidadFinal = EvaluacionPuntaje.puntosUniversidadFinal;
    float puntosFamiliaFinal = EvaluacionPuntaje.puntosFamiliaFinal;
    int contDormido = EvaluacionPuntaje.contadorDormido;

    string txtEscenario1 = "Parece ser que te dedicaste mucho al estudio. Sin embargo tu vida personal y salud se vieron seriamente afectados.";
    string txtEscenario2 = "Parece ser que lograste sacar tiempo para tu familia y vida personal. Sin embargo dejaste de lado el estudio y tu salud se vio seriamente afectados por no descansar.";
    string txtEscenario3 = "Parece ser que descuidaste tu salud, eso no es bueno a�n si lograste equilibrar la universidad y tu vida personal.";
    string txtEscenario4 = "Felicitaciones! Lograste equilibrar las distintas facetas de tu vida! Es todo un hito!";


    public int calcularPuntajeFinal()
    {
        int diffPuntajes = (int)Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal);
        float factorCastigo = 1;

        if(diffPuntajes>=5)
        {
            factorCastigo=2;
        }
        else if(diffPuntajes<5&&diffPuntajes>=2)
        {
            factorCastigo = 1.5f;
        }

        int puntFinal = (int)(puntosUniversidadFinal+puntosFamiliaFinal -(diffPuntajes*factorCastigo) -contDormido);
        Debug.Log("Puntuacion: "+puntFinal);
        return puntFinal;
    }

    public void mostrarPuntajes()
    {
        if(verCalculo==false)
        {
            txtPuntaje.text = "Puntaje final: " + calcularPuntajeFinal();
            verCalculo = true;
        }
        else
        {
            textoBoton.text = "Finalizar";
            if (escenario == 1)
            {
                txtPuntaje.text = txtEscenario1;
                escenario = 0;
            }
            else if (escenario == 2)
            {
                txtPuntaje.text = txtEscenario2;
                escenario = 0;
            }
            else if (escenario == 3)
            {
                txtPuntaje.text = txtEscenario3;
                escenario = 0;
            }
            else if (escenario == 4)
            {
                txtPuntaje.text = txtEscenario4;
                escenario = 0;
            }
            else if (escenario == 0)
            {
                esce1.SetActive(false);
                Debug.Log("click");
                SceneManager.LoadScene("Menu");
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        string textoPuntaje;
        if (contDormido == 1)
        {
            textoPuntaje = "Universidad: " + puntosUniversidadFinal + "\n" + "Familia: " + puntosFamiliaFinal + "\n \n" + "Te has quedado dormido contra tu voluntad en " + contDormido + " ocasi�n";
        }
        else
        {
            textoPuntaje = "Universidad: " + puntosUniversidadFinal + "\n" + "Familia: " + puntosFamiliaFinal + "\n \n" + "Te has quedado dormido contra tu voluntad en " + contDormido + " ocasiones";
        }

        Debug.Log(escenario);

        
        esce1.SetActive(true);
        txtPuntaje.text = textoPuntaje;
        


    }



    


}
