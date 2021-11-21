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

    private eventsAnimationsController eventsAnimationController;

    public float minSecondsBetweenSpawning = 3.0f;
    public float maxSecondsBetweenSpawning = 6.0f;

    public float velocidadPelota = 5.0f;
    public float tamanoPelota = 1.0f;
    public int bounce_min = 1;
    public int bounce_max = 6;
    public int player_bounces = 3;

    private float savedTime;
    private float secondsBetweenSpawning;
    private Vector2 direction;


    public int porcentajeEvento;
    public int porcentajeFamilia;
    public int porcentajeEnergia;
    public int porcentajeUniversidad;


    //Pelotas que rebotan por número de pelotas que no rebotan
    public int pelotasRebote =1;
    public int pelotasSinRebote = 2;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitForUICoroutine());


        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);

        setPorcentajesIniciales();
        StartCoroutine(shoot());

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

        GameObject canvas = GameObject.FindGameObjectWithTag("UIcanvas");

        eventsAnimationController = canvas.GetComponent<eventsAnimationsController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 reticlePos = reticle.transform.position;

        direction = reticlePos - (Vector2)transform.position;


    }

    void shootObject(int pRebotesJugador, int pPelota)
    {
        //Instanciaci�n del prefab para generar una nueva pelota

        GameObject[] pelotas = { pelotaPrefab, pelotaAmarilla, pelotaRoja, pelotaVerde };
        //GameObject pelotaact= pelotas[Random.Range(0, 4)];
        GameObject pelotaact = pelotas[pPelota];
        GameObject pelotaCopy = Instantiate(pelotaact, reticle.transform.position, Quaternion.identity);
        pelotaCopy.GetComponent<pelota_script>().speed = velocidadPelota;
        pelotaCopy.GetComponent<pelota_script>().tamano = tamanoPelota;
        pelotaCopy.GetComponent<pelota_script>().bounce_min = pRebotesJugador;
        pelotaCopy.GetComponent<pelota_script>().bounce_max = pRebotesJugador;
        pelotaCopy.GetComponent<pelota_script>().player_bounces = pRebotesJugador;
        pelotaCopy.GetComponent<pelota_script>().direccion = direction;
    }

    int randomParametro(int p1, int p2, int p3, int p4)
    {

        int suma = p1 + p2 + p3 + p4;
        int porcentaje = Random.Range(1, suma);

        if (porcentaje < p1)
        {
            return 0;
        }
        else if (porcentaje < p1 + p2)
        {
            return 1;
        }
        else if (porcentaje < p1 + p2 + p3)
        {
            return 2;
        }
        else
        {
            return 3;
        }

    }

    IEnumerator shoot()
    {
        int pelotasLanzadasRebote = 0;
        int pelotasLanzadasSinRebote = 0;

        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenSpawning);
            int tipoPelota = randomParametro(porcentajeEvento, porcentajeFamilia, porcentajeEnergia, porcentajeUniversidad);
            if (pelotasLanzadasSinRebote < pelotasSinRebote)
            {
                Debug.Log("Entró a pelotas sin rebote if"); 

                shootObject(1, tipoPelota);

                if(tipoPelota == 1 || tipoPelota == 3)
                {

                pelotasLanzadasSinRebote++;
                }
            }
            else if (pelotasLanzadasRebote < pelotasRebote)
            {
                Debug.Log("Entró a pelotas con rebote if");
                if (tipoPelota == 1 || tipoPelota ==3)
                {
                    Debug.Log("Entró a no pelotas blancas");
                    shootObject(player_bounces, tipoPelota);
                    pelotasLanzadasRebote++;
                }
                else
                {
                    Debug.Log("Entró a pelotas blancas o energía");
                    shootObject(1, tipoPelota);
                }

            }

            if (pelotasLanzadasRebote >= pelotasRebote && pelotasLanzadasSinRebote >= pelotasSinRebote)
            {
                pelotasLanzadasRebote = 0;
                pelotasLanzadasSinRebote = 0;

            }

            secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);

            Debug.Log("Pelotas con rebote lanzadas: "+pelotasLanzadasRebote +"\n"+
                "pelotas sin rebote lanzadas: "+pelotasLanzadasSinRebote);
        }


    }

    public void modificarRebote(int nPelotasSinRebote, int nPelotasRebote)
    {
        pelotasSinRebote = nPelotasSinRebote;
        pelotasRebote = nPelotasRebote;
    }

    public void setReboteInicial()
    {
        pelotasSinRebote = 1;
        pelotasRebote = 0;
    }

    public void modificarPorcentajes(int pEvento, int pFamilia, int pEnergia, int pUniversidad)
    {
        porcentajeEvento = pEvento;
        porcentajeFamilia = pFamilia;
        porcentajeEnergia = pEnergia;
        porcentajeUniversidad = pUniversidad;
    }

    public void setPorcentajesIniciales()
    {
        porcentajeEvento = 20;
        porcentajeFamilia = 30;
        porcentajeEnergia = 30;
        porcentajeUniversidad = 30;
    }


    public IEnumerator DebuffTamañoPelota()
    {
        mensajeria.lanzarMensaje("Te distrajiste con una película y tu productividad bajó");
        tamanoPelota = tamanoPelota / 2;

        eventoActivo = true;
        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.pelotaAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        tamanoPelota = tamanoPelota * 2;
        eventoActivo = false;
        //Debug.Log("Debuff terminado");
    }

    public IEnumerator DebuffVelocidadPelota()
    {
        mensajeria.lanzarMensaje("Vamos a coger las cosas con calma");

        velocidadPelota = velocidadPelota / 2;

        eventoActivo = true;
        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.pelotaAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        velocidadPelota = velocidadPelota * 2;
        eventoActivo = false;
        //Debug.Log("Debuff terminado");
    }

    public IEnumerator BuffVelocidadPelota()
    {
        mensajeria.lanzarMensaje("Tu concentración está por las nubes");

        velocidadPelota = velocidadPelota * 2;

        eventoActivo = true;
        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.pelotaAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        velocidadPelota = velocidadPelota / 2;
        eventoActivo = false;
        //Debug.Log("Debuff terminado");
    }

    public IEnumerator DebuffSpawnTime()
    {

        mensajeria.lanzarMensaje("Te sientes abrumado por la cantidad de cosas por hacer");

        minSecondsBetweenSpawning = 0.3f;
        maxSecondsBetweenSpawning = 0.7f;
        eventoActivo = true;

        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.pelotaAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        minSecondsBetweenSpawning = 0.5f;
        maxSecondsBetweenSpawning = 1.0f;
        eventoActivo = false;
        //Debug.Log("Debuff terminado");
    }

    public IEnumerator BuffSpawnTime()
    {

        mensajeria.lanzarMensaje("Por fin llegaron unos días un poco tranquilos");

        minSecondsBetweenSpawning = 2.0f;
        maxSecondsBetweenSpawning = 3.5f;
        eventoActivo = true;

        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.pelotaAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        minSecondsBetweenSpawning = 0.5f;
        maxSecondsBetweenSpawning = 1.0f;
        eventoActivo = false;
        //Debug.Log("Debuff terminado");
    }



}
