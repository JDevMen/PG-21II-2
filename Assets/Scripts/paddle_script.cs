using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_script : MonoBehaviour
{
    public float speed = 5f;

    private float input;

    public int numDormido;
    private bool estaDormido=false;

    //Puntos necesarios para empezar a ser castigado
    public int puntosInicioCastigo = 3;
    public int puntosAntesDeCastigo;

    public Mensajes mensajeria;

    public SpawnGameObject generadorScript;

    //Script castigo
    private castigoScript castigoScript;


    public eventsAnimationsController eventsAnimationController;

    public float eventTimer = 0f;
    private bool DebuffInput;
    public bool eventoActivo = false;


    private GameObject iconosEventos;
    private GameObject iconoPelota;
    private GameObject iconoJugador;


    private AudioSource audioSource;
    public AudioClip Pong;
    public AudioClip eventSound;
    public AudioClip yawnSound;


    public float points = 0f;

    //Puntos del jugador
    public float puntosEnergia = 0f;
    public float puntosUniversidad = 0f;
    public float puntosFamilia = 0f;

    private Rigidbody2D rb;

    public Camera camara;

    private GameObject snooze;
    private BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {

        
        StartCoroutine(waitForUICoroutine());
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            Debug.LogError("Player missing Rigidbody2D component");
        }

        puntosEnergia = 10;
        GameObject Generador = GameObject.FindGameObjectWithTag("Generador");
        audioSource = GetComponent<AudioSource>();
        generadorScript = Generador.GetComponent<SpawnGameObject>();
        GameObject piso = GameObject.FindGameObjectWithTag("Piso");
        castigoScript = piso.GetComponent<castigoScript>();
        if(castigoScript == null)
        {
            Debug.Log("No hay script para manejar castigos");
        }
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        snooze = gameObject.transform.GetChild(0).gameObject;

        VolumenMusi.VolumenMusica(camara);


    }

    IEnumerator waitForUICoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSecondsRealtime(1);
        GameObject UIcanvas = GameObject.FindGameObjectWithTag("UIcanvas");
        Debug.Log(UIcanvas);

        mensajeria = UIcanvas.GetComponent<Mensajes>();
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        GameObject canvas = GameObject.FindGameObjectWithTag("UIcanvas");

        iconosEventos = canvas.transform.Find("iconosEventos").gameObject;

        iconoPelota = iconosEventos.transform.Find("eventoPelotaIcon").gameObject;
        iconoJugador = iconosEventos.transform.Find("eventoJugadorIcon").gameObject;

        eventsAnimationController = canvas.GetComponent<eventsAnimationsController>();


    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    // Update is called once per frame
    void Update()
    {   
        input = Input.GetAxisRaw("Horizontal");
        if(DebuffInput)
        {

            input = -input;
        }
        rb.velocity = Vector2.right * input * speed;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * input * speed;
        puntosEnergia-=0.008f*Time.timeScale;
        if(puntosEnergia <=0){
                puntosEnergia=10;

                StartCoroutine(Dormir());

            }

        if (iconosEventos != null)
        {
            if (generadorScript.eventoActivo)
                iconoPelota.SetActive(true);
            else
                iconoPelota.SetActive(false);

            if (this.eventoActivo)
            {
                iconoJugador.SetActive(true);
            }
            else
                iconoJugador.SetActive(false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("GreenBall"))
        {
            puntosUniversidad++;
            castigoScript.resetUniversidadCastigo();
            audioSource.clip= Pong;
            audioSource.Play();
            
        }
        if (collision.gameObject.CompareTag("YellowBall"))
        {
            puntosFamilia++;
            castigoScript.resetFamiliaCastigo();
            audioSource.clip= Pong;
            audioSource.Play();
        }
        if (collision.gameObject.CompareTag("RedBall"))
        {
            puntosEnergia++;

            if (puntosEnergia >10)
            {
                puntosEnergia = 10;
            }
            audioSource.clip= Pong;
            audioSource.Play();
        }
        if (collision.gameObject.CompareTag("Evento"))
        {

            audioSource.clip= eventSound;
            audioSource.Play();
            int num = (int) Random.Range(1 , 11);
            if ((num >= 6 && !generadorScript.eventoActivo) || (num < 6 && !this.eventoActivo))
            {
                switch (num)
                {
                    case 1:
                        StartCoroutine(buff());
                        eventsAnimationController.changePlayerEventSprite("playerEvent1");
                        break;

                    case 2:
                        StartCoroutine(debuff());
                        eventsAnimationController.changePlayerEventSprite("playerEvent4");
                        break;

                    case 3:
                        StartCoroutine(scaleDebuff());
                        eventsAnimationController.changePlayerEventSprite("playerEvent2");
                        break;
                    case 4:
                        StartCoroutine(scaleBuff());
                        eventsAnimationController.changePlayerEventSprite("playerEvent3");
                        break;
                    case 5:
                        StartCoroutine(debuffInput());
                        eventsAnimationController.changePlayerEventSprite("playerEvent5");
                        break;
                    case 6:
                        StartCoroutine(generadorScript.DebuffTamañoPelota());
                        eventsAnimationController.changeBallEventSprite("ballEvent1");
                        break;
                    case 7:
                        StartCoroutine(generadorScript.DebuffVelocidadPelota());
                        eventsAnimationController.changeBallEventSprite("ballEvent2");
                        break;
                    case 8:
                        StartCoroutine(generadorScript.BuffVelocidadPelota());
                        eventsAnimationController.changeBallEventSprite("ballEvent3");
                        break;
                    case 9:
                        StartCoroutine(generadorScript.DebuffSpawnTime());
                        eventsAnimationController.changeBallEventSprite("ballEvent4");
                        break;
                    case 10:
                        StartCoroutine(generadorScript.BuffSpawnTime());
                        eventsAnimationController.changeBallEventSprite("ballEvent5");
                        break;

                    default:
                        break;
                }


            }
        }


    }


    public IEnumerator Dormir()
    {
        audioSource.clip= yawnSound;
        audioSource.Play();
        mensajeria.lanzarMensaje("Te has quedado dormido");
        snooze.SetActive(true);
        estaDormido =true;
        boxCollider.enabled = !boxCollider.enabled;
        numDormido++;
        float prevSpeed =speed;
        speed = speed * 0;
        yield return new WaitForSeconds(2.5f);
        boxCollider.enabled = !boxCollider.enabled;
        snooze.SetActive(false);
        speed = prevSpeed;
        estaDormido =false;
        Debug.Log("Buff terminado");
    }


    IEnumerator buff()
    {
        mensajeria.lanzarMensaje("Has descansado bien los últimos 2 dias tu velocidad aumenta");

        speed = speed * 2;
        eventoActivo = true;
        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.jugadorAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        if(estaDormido)
        {
            yield return new WaitForSeconds(2.5f);
        }
        speed = speed / 2;
        eventoActivo = false;
        Debug.Log("Buff terminado");

    }

    IEnumerator scaleDebuff()
    {
        transform.localScale = new Vector3(0.5f,0.5f,1);
        eventoActivo = true;
        mensajeria.lanzarMensaje("Hoy tu transporte se demoró, sera mas dïficil cumplir tus tareas");

        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.jugadorAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        transform.localScale = new Vector3(2, 2f, 1);

        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }

    IEnumerator scaleBuff()
    {
        transform.localScale = new Vector3(3.5f, 2f, 1);
        eventoActivo = true;
        mensajeria.lanzarMensaje("La comida de hoy te dio mucho gusto te sera mas facil cumplir tus tareas");

        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.jugadorAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        transform.localScale = new Vector3(2, 2f, 1);

        eventoActivo = false;
        Debug.Log("Buff terminado");
    }

    IEnumerator debuff()
    {
        speed = speed / 3;
        eventoActivo = true;
        mensajeria.lanzarMensaje("Tuviste una pesadilla, la noche no fue buena para ti y no descansaste");


        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.jugadorAnimationCoroutine(2));
        yield return new WaitForSeconds(2);

        if(estaDormido)
        {
            yield return new WaitForSeconds(2.5f);
        }
        speed = speed * 3;
        eventoActivo = false;

        Debug.Log("Debuff terminado");
    }

    IEnumerator debuffInput()
    {
        DebuffInput = true;
        eventoActivo = true;
        mensajeria.lanzarMensaje("Unos amigos te invitaron a salir anoche y te divertiste demasiado hoy tienes mareo al despertar");

        yield return new WaitForSeconds(5);
        StartCoroutine(eventsAnimationController.jugadorAnimationCoroutine(2));
        yield return new WaitForSeconds(2);
        DebuffInput = false;
        eventoActivo = false;

        Debug.Log("Debuff terminado");
    }


    public float getPuntosEnergia()
    {
        return puntosEnergia;
    }

    public float getPuntosUniversidad()
    {
        return puntosUniversidad;
    }

    public float getPuntosFamilia()
    {
        return puntosFamilia;
    }

    
}
