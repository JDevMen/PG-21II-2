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

    public GameObject botonFin;
    public GameObject botonReintentar;
    public TMP_Text textoBoton;

    private AudioSource audioSource;
    public AudioClip ganadorSound;
    public AudioClip perdedorSound;


    int escenario = EvaluacionPuntaje.escenarioCargar;

    float puntosEnergiaFinal = EvaluacionPuntaje.puntosEnergiaFinal;
    float puntosUniversidadFinal = EvaluacionPuntaje.puntosUniversidadFinal;
    float puntosFamiliaFinal = EvaluacionPuntaje.puntosFamiliaFinal;
    int contDormido = EvaluacionPuntaje.contadorDormido;
    float factorCastigo = 1;


    string txtEscenario1 = "Parece ser que te dedicaste mucho al estudio. Sin embargo tu vida personal y salud se vieron seriamente afectados.";
    string txtEscenario2 = "Parece ser que lograste sacar tiempo para tu familia y vida personal. Sin embargo dejaste de lado el estudio y tu salud se vio seriamente afectados por no descansar.";
    string txtEscenario3 = "Parece ser que descuidaste tu salud, eso no es bueno a�n si lograste equilibrar la universidad y tu vida personal.";
    string txtEscenario4 = "Felicitaciones! Lograste equilibrar las distintas facetas de tu vida! Es todo un hito!";


    public int calcularPuntajeFinal()
    {
        int diffPuntajes = (int)Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal);

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
            txtPuntaje.text = "Puntaje Universidad: " + puntosUniversidadFinal*10+"\n"+"\n";
            txtPuntaje.text += "Puntaje Ocio: " + puntosFamiliaFinal*10+"\n"+"\n";
            txtPuntaje.text += "Castigo Veces Dormido: " + -contDormido*10+"\n"+"\n";
            txtPuntaje.text += "Castigo Desequilibrio: " + -(Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal)*factorCastigo)*10+"\n"+"\n";
               
            

            txtPuntaje.text += "Puntaje final: " + 10*calcularPuntajeFinal();
            verCalculo = true;
        }
        else
        {
            botonReintentar.SetActive(true);
            Vector3 pos = new Vector3(250, 0, 0);
            botonFin.transform.localPosition += pos;
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

    public void reintentar()
    {
        SceneManager.LoadScene("Juego");
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        AudioSource audioSource = camera.GetComponent<AudioSource>();

        if(puntosFamiliaFinal>=17&&puntosUniversidadFinal>=17)
            audioSource.clip= ganadorSound;
        else
            audioSource.clip= perdedorSound;
        Debug.Log(ganadorSound);

        audioSource.Play(); 
        calcularPuntajeFinal();
        string textoPuntaje;
        if (contDormido == 1)
        {
            textoPuntaje = "Universidad: " + puntosUniversidadFinal + "\n\n" + "Ocio: " + puntosFamiliaFinal + "\n\nEl desbalanceo en tus estadisticas fue: "
            +Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal)+ "\n\nLo que representa un castido de: " +factorCastigo+" x " +Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal)+
            " = " +Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal)*factorCastigo + "\n\nY te has quedado dormido contra tu voluntad en " + contDormido + " ocasi�n";
        }
        else
        {
            textoPuntaje = "Universidad: " + puntosUniversidadFinal + "\n\n" + "Ocio: " + puntosFamiliaFinal + "\n\nEl desbalanceo en tus estadisticas fue: "
            +Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal)+ "\n\nLo que representa un castido de: " +factorCastigo+" x " +Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal)+
            " = " +Mathf.Abs(puntosUniversidadFinal-puntosFamiliaFinal)*factorCastigo +  "\n\nTe has quedado dormido contra tu voluntad en " + contDormido + " ocasiones";
        }

        Debug.Log(escenario);

        
        esce1.SetActive(true);
        txtPuntaje.text = textoPuntaje;
        


    }



    


}
