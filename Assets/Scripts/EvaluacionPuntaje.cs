using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvaluacionPuntaje : MonoBehaviour
{
    private Temporizador temp;
    private int tiempo;
    public static int escenarioCargar;

    private paddle_script jugadorScript;

    //puntos del jugador
    private float puntosEnergia;
    private float puntosUniversidad;
    private float puntosFamilia;

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

        puntosEnergia = jugadorScript.getPuntosEnergia();
        puntosUniversidad = jugadorScript.getPuntosUniversidad();
        puntosFamilia = jugadorScript.getPuntosFamilia();

        if (tiempo == 0)
        {

            if (puntosUniversidad > puntosFamilia + 5 && puntosUniversidad > puntosEnergia + 5)
            {
                escenarioCargar = 1;
            }
            else if (puntosFamilia > puntosUniversidad + 5 && puntosFamilia > puntosEnergia + 5)
            {
                escenarioCargar = 2;
            }
            else if (puntosEnergia > puntosUniversidad + 5 && puntosEnergia > puntosFamilia + 5)
            {
                escenarioCargar = 3;
            }
            else
            {
                escenarioCargar = 4;
            }

            SceneManager.LoadScene("EscenariosFinal");
        }
    }

    


}
