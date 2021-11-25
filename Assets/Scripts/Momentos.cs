using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Momentos : MonoBehaviour
{

    public SpawnGameObject lanzadorScript;
    private Temporizador temp;
    private float tiempo;
    public GameObject textoMomentoObj;
    private Animator momentoAnimator;
    public TMP_Text textoMomentos;

    public float duracionParpadeo= 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject UIcanvas = GameObject.FindGameObjectWithTag("UIcanvas");
        GameObject Generador = GameObject.FindGameObjectWithTag("Generador");

        temp = UIcanvas.GetComponent<Temporizador>();
        lanzadorScript = Generador.GetComponent<SpawnGameObject>();

        momentoAnimator = textoMomentoObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = temp.getTiempo();

        if (tiempo == getTiempoMomento(4))
        {
            Debug.Log("Comienza momento 1");
            StartCoroutine(lanzarMomento1(getTiempoSemana()));
        }

        if (tiempo == getTiempoMomento(9))
        {
            Debug.Log("Comienza momento 2");
            StartCoroutine(lanzarMomento2(getTiempoSemana()));
        }

        if (tiempo == getTiempoMomento(13))
        {
            Debug.Log("Comienza momento 3");
            StartCoroutine(lanzarMomento3(getTiempoSemana()));
        }


    }

    IEnumerator parpadeo()
    {

        Debug.LogWarning("Entró a parpadeo");

        momentoAnimator.Play("lookAtMe");
        yield return new WaitForSeconds(duracionParpadeo);
        momentoAnimator.Play("Default");
    }

    IEnumerator lanzarMomento1(float duracionSemana)
    {
        textoMomentoObj.SetActive(true);
        textoMomentos.text = "¡Periodo de Parciales!";
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject generador = GameObject.FindGameObjectWithTag("Generador");
        AudioSource audioSource = camera.GetComponent<AudioSource>();

        audioSource.pitch=1.2f;
        lanzadorScript = generador.GetComponent<SpawnGameObject>();

        lanzadorScript.modificarPorcentajes(1, 30, 30, 40);
        lanzadorScript.modificarRebote(1,5);

        StartCoroutine(parpadeo());
        yield return new WaitForSeconds(duracionSemana*2);


        Debug.Log("Termina el momento 1");
        audioSource.pitch=1;

        lanzadorScript.setPorcentajesIniciales();
        lanzadorScript.setReboteInicial();
        textoMomentoObj.SetActive(false);
    }




    IEnumerator lanzarMomento2(float duracionSemana)
    {
        textoMomentoObj.SetActive(true);
        textoMomentos.text = "Semana de Receso";
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject generador = GameObject.FindGameObjectWithTag("Generador");
        AudioSource audioSource = camera.GetComponent<AudioSource>();

        audioSource.pitch = 1.2f;
        lanzadorScript = generador.GetComponent<SpawnGameObject>();

        lanzadorScript.modificarPorcentajes(10, 30, 35, 20);

        StartCoroutine(parpadeo());
        yield return new WaitForSeconds(duracionSemana * 2);


        Debug.Log("Termina el momento 2");
        audioSource.pitch = 1;

        lanzadorScript.setPorcentajesIniciales();
        lanzadorScript.setReboteInicial();
        textoMomentoObj.SetActive(false);
    }

    IEnumerator lanzarMomento3(float duracionSemana)
    {
        textoMomentoObj.SetActive(true);
        textoMomentos.text = "¡Periodo de finales!";
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject generador = GameObject.FindGameObjectWithTag("Generador");
        AudioSource audioSource = camera.GetComponent<AudioSource>();

        audioSource.pitch = 1.2f;
        lanzadorScript = generador.GetComponent<SpawnGameObject>();

        lanzadorScript.modificarPorcentajes(10, 30, 20, 40);
        lanzadorScript.modificarRebote(1, 5);

        StartCoroutine(parpadeo());
        yield return new WaitForSeconds(duracionSemana * 4);


        Debug.Log("Termina el momento 3");
        audioSource.pitch = 1;

        lanzadorScript.setPorcentajesIniciales();
        lanzadorScript.setReboteInicial();
        textoMomentoObj.SetActive(false);
    }


    public float getTiempoMomento(int nSemana)
    {
        float tiempoMomento;
        float duracionSemana = getTiempoSemana();
        float semanaMomento = duracionSemana * nSemana;

        tiempoMomento = Mathf.FloorToInt(semanaMomento);
        return tiempoMomento;
    }

    public float getTiempoSemana()
    {
        return temp.tiempoParaCalcular / 16;
    }
}
