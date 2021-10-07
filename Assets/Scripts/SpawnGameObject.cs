using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    public GameObject pelotaPrefab;
    public GameObject pelotaAmarilla;
    public GameObject pelotaRoja;
    public GameObject pelotaVerde;
    public GameObject reticle;

    public Mensajes mensajeria;
    public bool eventoActivo = false;
    private Temporizador temp;


    public float minSecondsBetweenSpawning = 3.0f;
    public float maxSecondsBetweenSpawning = 6.0f;

    public float velocidadPelota = 5.0f;
    public float tamanoPelota = 1.0f;
    public int bounce_min = 1;
    public int bounce_max = 6;
    public int player_bounces = 1;

    private float savedTime;
    private float secondsBetweenSpawning;
    private Vector2 direction;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitForUICoroutine());


        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
    }

    IEnumerator waitForUICoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSecondsRealtime(1);
        GameObject UIcanvas = GameObject.FindGameObjectWithTag("UIcanvas");
        Debug.Log(UIcanvas);

        mensajeria = UIcanvas.GetComponent<Mensajes>();
        temp = UIcanvas.GetComponent<Temporizador>();
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 reticlePos = reticle.transform.position;

        direction = reticlePos - (Vector2)transform.position;

        if (Input.GetKeyDown(KeyCode.V) && !eventoActivo)
        {
            Debug.Log("Se lanza evento 1");
            StartCoroutine(DebuffTamañoPelota());
        }

        if (Input.GetKeyDown(KeyCode.C) && !eventoActivo)
        {
            Debug.Log("Se lanza evento 2");
            StartCoroutine(DebuffVelocidadPelota());
        }

        if (Input.GetKeyDown(KeyCode.X) && !eventoActivo)
        {
            Debug.Log("Se lanza evento 3");
            StartCoroutine(DebuffSpawnTime());
        }

        if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
        {
            
            //Instanciaci�n del prefab para generar una nueva pelota
            shootObject();
            savedTime = Time.time; // store for next spawn
            secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);

            
        }

        
    }

    void shootObject()
    {
        //Instanciaci�n del prefab para generar una nueva pelota

        GameObject[] pelotas = {pelotaPrefab,pelotaAmarilla,pelotaRoja,pelotaVerde};
        GameObject pelotaact= pelotas[Random.Range(0, 4)];
        GameObject pelotaCopy = Instantiate(pelotaact, reticle.transform.position, Quaternion.identity);
        pelotaCopy.GetComponent<pelota_script>().speed = velocidadPelota;
        pelotaCopy.GetComponent<pelota_script>().tamano = tamanoPelota;
        pelotaCopy.GetComponent<pelota_script>().bounce_min = bounce_min;
        pelotaCopy.GetComponent<pelota_script>().bounce_max = bounce_max;
        pelotaCopy.GetComponent<pelota_script>().player_bounces = player_bounces;
        pelotaCopy.GetComponent<pelota_script>().direccion = direction;
    }

    public IEnumerator DebuffTamañoPelota()
    {
        mensajeria.lanzarMensaje("Te distrajiste con una película y tu productividad bajó");
        tamanoPelota = tamanoPelota/ 2;

        eventoActivo = true;
        yield return new WaitForSeconds(7);
        tamanoPelota = tamanoPelota * 2;
        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }

    public IEnumerator DebuffVelocidadPelota()
    {
        mensajeria.lanzarMensaje("Vamos a coger las cosas con calma");

        velocidadPelota = velocidadPelota * 2;

        eventoActivo = true;
        yield return new WaitForSeconds(7);
        velocidadPelota = velocidadPelota / 2;
        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }

    public IEnumerator BuffVelocidadPelota()
    {
        mensajeria.lanzarMensaje("Tu concentración está por las nubes");

        velocidadPelota = velocidadPelota / 2;

        eventoActivo = true;
        yield return new WaitForSeconds(7);
        velocidadPelota = velocidadPelota * 2;
        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }

    public IEnumerator DebuffSpawnTime()
    {

        mensajeria.lanzarMensaje("Te sientes abrumado por la cantidad de cosas por hacer");

        minSecondsBetweenSpawning = 0.5f;
        maxSecondsBetweenSpawning = 1.5f;
        eventoActivo = true;
        
        yield return new WaitForSeconds(7);
        minSecondsBetweenSpawning = 3.0f;
        maxSecondsBetweenSpawning = 6.0f;
        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }

    public IEnumerator BuffSpawnTime()
    {

        mensajeria.lanzarMensaje("Por fin llegaron unos días un poco tranquilos");

        minSecondsBetweenSpawning = 0.5f;
        maxSecondsBetweenSpawning = 1.5f;
        eventoActivo = true;

        yield return new WaitForSeconds(7);
        minSecondsBetweenSpawning = 3.0f;
        maxSecondsBetweenSpawning = 6.0f;
        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }



}
