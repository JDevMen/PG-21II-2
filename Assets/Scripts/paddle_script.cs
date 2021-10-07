using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_script : MonoBehaviour
{
    public float speed = 5f;

    private float input;


    public Mensajes mensajeria;

    public SpawnGameObject generadorScript;

    

   
    public float eventTimer = 0f;
    private bool DebuffInput;
    public bool eventoActivo = false;
   
        
    public float points = 0f;

    //Puntos del jugador
    public float puntosEnergia = 0f;
    public float puntosUniversidad = 0f;
    public float puntosFamilia = 0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(waitForUICoroutine());
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            Debug.LogError("Player missing Rigidbody2D component");
        }

        GameObject Generador = GameObject.FindGameObjectWithTag("Generador");
        generadorScript = Generador.GetComponent<SpawnGameObject>();

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
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GreenBall"))
        {
            puntosUniversidad++;
        }
        if (collision.gameObject.CompareTag("YellowBall"))
        {
            puntosFamilia++;
        }
        if (collision.gameObject.CompareTag("RedBall"))
        {
            puntosEnergia++;
        }
        if (collision.gameObject.CompareTag("Evento"))
        {
            int num = (int) Random.Range(1 , 11);
            if ((num >= 6 && !generadorScript.eventoActivo) || (num < 6 && !this.eventoActivo))
            {
                switch (num)
                {
                    case 1:
                        StartCoroutine(buff());
                        break;

                    case 2:
                        StartCoroutine(debuff());
                        break;

                    case 3:
                        StartCoroutine(scaleDebuff());
                        break;
                    case 4:
                        StartCoroutine(scaleBuff());
                        break;
                    case 5:
                        StartCoroutine(debuffInput());
                        break;
                    case 6:
                        StartCoroutine(generadorScript.DebuffTamañoPelota());
                        break;
                    case 7:
                        StartCoroutine(generadorScript.DebuffVelocidadPelota());
                        break;
                    case 8:
                        StartCoroutine(generadorScript.BuffVelocidadPelota());
                        break;
                    case 9:
                        StartCoroutine(generadorScript.DebuffSpawnTime());
                        break;
                    case 10:
                        StartCoroutine(generadorScript.BuffSpawnTime());
                        break;

                    default:
                        break;
                }


            }
        }


    }


    public IEnumerator Dormir()
    {
        mensajeria.lanzarMensaje("Te haz quedado dormido ");

        speed = speed * 0;
        eventoActivo = true;
        yield return new WaitForSeconds(2.5f);
        speed = 5;
        eventoActivo = false;
        Debug.Log("Buff terminado");
    }


    IEnumerator buff()
    {
        mensajeria.lanzarMensaje("Haz descansado bien los ultimos 2 dias tu velocidad aumenta");

        speed = speed * 2;
        eventoActivo = true;
        yield return new WaitForSeconds(7);
        speed = speed / 2;
        eventoActivo = false;
        Debug.Log("Buff terminado");
    }

    IEnumerator scaleDebuff()
    {
        transform.localScale = new Vector3(0.5f,0.5f,1);
        eventoActivo = true;
        mensajeria.lanzarMensaje("Hoy tu transporte se demoró, sera mas dificil cumplir tus tareas");
    
        yield return new WaitForSeconds(7);
        transform.localScale = new Vector3(2, 0.5f, 1);

        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }

    IEnumerator scaleBuff()
    {
        transform.localScale = new Vector3(3.5f, 0.5f, 1);
        eventoActivo = true;
        mensajeria.lanzarMensaje("La comida de hoy te dio gusto mucho te sera mas facil cumplir tus tareas");

        yield return new WaitForSeconds(7);
        transform.localScale = new Vector3(2, 0.5f, 1);

        eventoActivo = false;
        Debug.Log("Buff terminado");
    }

    IEnumerator debuff()
    {
        speed = speed / 3;
        eventoActivo = true;
        mensajeria.lanzarMensaje("Tuviste una pesadilla, la noche no fue buena para ti y no descansaste");


        yield return new WaitForSeconds(7);
        speed = speed * 3;
        eventoActivo = false;

        Debug.Log("Debuff terminado");
    }

    IEnumerator debuffInput()
    {
        DebuffInput = true;
        eventoActivo = true;
        mensajeria.lanzarMensaje("Unos amigos te invitaron a salir anoche y te divertiste demasiado hoy tienes mareo al despertar");

        yield return new WaitForSeconds(7);
        DebuffInput = false;
        eventoActivo = false;

        Debug.Log("Debuff terminado");
    }

        

    //private void FixedUpdate()
    //{
    //    GetComponent<Rigidbody2D>().velocity = Vector2.right * input * speed;

    //}


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
