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
    public int puntosCastigo = 1;


    private eventsAnimationsController animationController;

    private bool warningFamilia = false;
    private bool warningUniversidad = false;
    private bool dangerFamilia = false;
    private bool dangerUniversidad = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        jugadorScript = jugador.GetComponent<paddle_script>();
        puntosParaCastigo = jugadorScript.puntosInicioCastigo;
        puntosAntesCastigo = jugadorScript.puntosAntesDeCastigo;
        //Debug.Log("puntos para castigo " + puntosParaCastigo);
        StartCoroutine(waitForUIcourutine());

    }

    IEnumerator waitForUIcourutine()
    {
        yield return new WaitForSecondsRealtime(1);
        animationController = GameObject.FindGameObjectWithTag("UIcanvas").GetComponent<eventsAnimationsController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject pelotaColisionada = collision.gameObject;

        if (pelotaColisionada.CompareTag("YellowBall"))
        {
            puntosFamilia++;
            audioSource.Play();
        }

        else if (pelotaColisionada.CompareTag("GreenBall"))
        {
            puntosUniversidad++;
            audioSource.Play();
        }
        else if (pelotaColisionada.CompareTag("RedBall"))
            audioSource.Play();


        string debugMessage = "";

        debugMessage += "Numero de pelotasFamilia caidas: " + puntosFamilia + "\n";

        debugMessage += "Numero de pelotasUniversidad caidas: " + puntosUniversidad + "\n";

        Debug.Log(debugMessage);

        if (puntosFamilia >= puntosAntesCastigo && puntosFamilia < puntosParaCastigo && !warningFamilia && pelotaColisionada.CompareTag("YellowBall"))
        {
            warningFamilia = true;
            animationController.activateFamiliaWarningAnimation();

        }
        if (puntosUniversidad >= puntosAntesCastigo && puntosUniversidad < puntosParaCastigo && !warningUniversidad && pelotaColisionada.CompareTag("GreenBall"))
        {
            warningUniversidad = true;
            animationController.activateUniversidadWarningAnimation();

        }

        if (puntosFamilia >= puntosParaCastigo && pelotaColisionada.CompareTag("YellowBall"))
        {
            Debug.Log("Entró a puntos para castigo ocio");
            if (warningFamilia)
            {
                warningFamilia = false;
                animationController.deactivatefamiliaWarningAnimation();
            }
            if (!dangerFamilia)
            {
                dangerFamilia = true;
                animationController.activateFamiliaDangerAnimation();
            }

            castigarFamilia();
        }
        if (puntosUniversidad >= puntosParaCastigo && pelotaColisionada.CompareTag("GreenBall"))
        {
            Debug.Log("Entró a puntos para castigo estudio");

            if (warningUniversidad)
            {
                warningUniversidad = false;
                animationController.deactivateUniversidadWarningAnimation();
            }
            if (!dangerUniversidad)
            {
                dangerUniversidad = true;
                animationController.activateUniversidadDangerAnimation();
            }
            castigarUniversidad();
        }
    }

    public void resetFamiliaCastigo()
    {
        puntosFamilia = 0;
        if (warningFamilia)
        {
            animationController.deactivatefamiliaWarningAnimation();
        }
        else if (dangerFamilia)
        {
            animationController.deactivatefamiliaDangerAnimation();
        }

        warningFamilia = false;
        dangerFamilia = false;
    }
    public void resetUniversidadCastigo()
    {
        puntosUniversidad = 0;
        if (warningUniversidad)
        {
            animationController.deactivateUniversidadWarningAnimation();
        }
        else if (dangerUniversidad)
        {
            animationController.deactivateUniversidadDangerAnimation();
        }

        warningUniversidad = false;
        dangerUniversidad = false;

    }

    public void castigarFamilia()
    {
        if (jugadorScript.puntosFamilia > 0)
            jugadorScript.puntosFamilia -= puntosCastigo;
        //Debug.Log("Castigado en puntos de familia");
    }
    public void castigarUniversidad()
    {
        if (jugadorScript.puntosUniversidad > 0)
            jugadorScript.puntosUniversidad -= puntosCastigo;
        //Debug.Log("Castigado en puntos de universidad");
    }



}
