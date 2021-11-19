using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvaluacionPuntaje : MonoBehaviour
{
    private Temporizador temp;
    private float tiempo;
    public static int escenarioCargar;
    public static float puntosEnergiaFinal;
    public static float puntosUniversidadFinal;
    public static float puntosFamiliaFinal;
    public static int contadorDormido;

    private paddle_script jugadorScript;

    //puntos del jugador
    private float puntosEnergia;
    private float puntosUniversidad;
    private float puntosFamilia;
    private int contDormido;

    // Start is called before the first frame update
    void Start()
    {
        GameObject UIcanvas = GameObject.FindGameObjectWithTag("UIcanvas");

        temp = UIcanvas.GetComponent<Temporizador>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            jugadorScript = player.GetComponent<paddle_script>();
            Debug.Log("Se encontr� y asign� script de control del jugador.");
            Debug.Log("-------------------------------");
        }
    }

        // Update is called once per frame
        void Update()
    {
        tiempo = temp.getTiempo();
        if (jugadorScript != null)
        {
            puntosEnergia = jugadorScript.getPuntosEnergia();
            puntosUniversidad = jugadorScript.getPuntosUniversidad();
            puntosFamilia = jugadorScript.getPuntosFamilia();
            contDormido = jugadorScript.numDormido;

            if (tiempo == temp.tiempoParaCalcular)
            {
                puntosEnergiaFinal = puntosEnergia;
                puntosFamiliaFinal = puntosFamilia;
                puntosUniversidadFinal = puntosUniversidad;
                contadorDormido = contDormido;


                if (puntosEnergia <=3)
                {
                    escenarioCargar = 3;
                }
                else if (puntosFamilia > puntosUniversidad + 2 )
                {
                    escenarioCargar = 2;
                }
                else if (puntosUniversidad > puntosFamilia + 2)
                {
                    escenarioCargar = 1;
                }
                else
                {
                    escenarioCargar = 4;
                }

                SceneManager.LoadScene("EscenariosFinal");
            }
        }
    }

    


}
