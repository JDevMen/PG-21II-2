using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castigoScript : MonoBehaviour
{
    private int puntosFamilia = 0;
    private int puntosUniversidad = 0;

    private paddle_script jugadorScript;
    private int puntosParaCastigo;
    private int puntosAntesCastigo;
    public int puntosCastigo=1;

    private eventsAnimationsController animationController;

    private bool warningFamilia = false;
    private bool warningUniversidad = false;
    private bool dangerFamilia = false;
    private bool dangerUniversidad= false;

    private void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        jugadorScript = jugador.GetComponent<paddle_script>();
        puntosParaCastigo = jugadorScript.puntosInicioCastigo;
        puntosAntesCastigo = jugadorScript.puntosAntesDeCastigo;
        Debug.Log("puntos para castigo " + puntosParaCastigo);

        animationController = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<eventsAnimationsController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject pelotaColisionada = collision.gameObject;

        if (pelotaColisionada.CompareTag("YellowBall"))
            puntosFamilia++;

        else if (pelotaColisionada.CompareTag("GreenBall"))
            puntosUniversidad++;

        string debugMessage = "";

        debugMessage += "Numero de pelotasFamilia caidas: " + puntosFamilia + "\n";

        debugMessage += "Numero de pelotasUniversidad caidas: " + puntosUniversidad + "\n";

        Debug.Log(debugMessage);

        if(puntosFamilia>= puntosAntesCastigo && puntosFamilia<puntosParaCastigo)
        {

        }

        if (puntosFamilia >= puntosParaCastigo && pelotaColisionada.CompareTag("YellowBall"))
        {
            castigarFamilia();



        }
        if (puntosUniversidad >= puntosParaCastigo && pelotaColisionada.CompareTag("GreenBall"))
            castigarUniversidad();
    }

    public void resetFamiliaCastigo()
    {
        puntosFamilia = 0;
    }
    public void resetUniversidadCastigo()
    {
        puntosUniversidad = 0;
    }

    public void castigarFamilia()
    {
        if(jugadorScript.puntosFamilia>0)
        jugadorScript.puntosFamilia -= puntosCastigo;
        Debug.Log("Castigado en puntos de familia");
    }
    public void castigarUniversidad()
    {
        if(jugadorScript.puntosUniversidad>0)
        jugadorScript.puntosUniversidad -= puntosCastigo;
        Debug.Log("Castigado en puntos de universidad");
    }



}
