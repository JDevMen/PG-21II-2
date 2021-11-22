using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momentos : MonoBehaviour
{

    public SpawnGameObject lanzadorScript;
    private Temporizador temp;
    private float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        GameObject UIcanvas = GameObject.FindGameObjectWithTag("UIcanvas");
        GameObject Generador = GameObject.FindGameObjectWithTag("Generador");

        temp = UIcanvas.GetComponent<Temporizador>();
        lanzadorScript = Generador.GetComponent<SpawnGameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = temp.getTiempo();

        if (tiempo == getTiempoMomento(4))
        {
            Debug.Log("Comienza momento 1");
            StartCoroutine(lanzarMomento(getTiempoSemana()));
        }

        
    }


    IEnumerator lanzarMomento(float duracionSemana)
    {

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject generador = GameObject.FindGameObjectWithTag("Generador");
        AudioSource audioSource = camera.GetComponent<AudioSource>();

        audioSource.pitch=1.2f;
        lanzadorScript = generador.GetComponent<SpawnGameObject>();

        lanzadorScript.modificarPorcentajes(1, 30, 30, 30);
        lanzadorScript.modificarRebote(1,5);

        yield return new WaitForSeconds(duracionSemana*3);


        Debug.Log("Termina el momento");
        audioSource.pitch=1;

        lanzadorScript.setPorcentajesIniciales();
        lanzadorScript.setReboteInicial();
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
