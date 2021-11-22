using System;
using UnityEngine;

public class pelota_script : MonoBehaviour
{
    //Velocidad inicial de la pelota
    public float speed = 5f;

    //Tamaño inicial de la pelota
    public float tamano = 1.0f;

    //Variables rebote 
    public int bounce_min = 1;
    public int bounce_max = 6;
    public int player_bounces =  1;

    private PhysicsMaterial2D material;

    //Variable factor cambio de velocidad (magnitud de vector velocidad)
    public float factorCambioVelocidad = 1.2f;

    //Velocidad mínima que debe tener la pelota
    public float minVelocidad = 3f ; 

    //Velocidad máxima alcanzable por la pelota
    public float maxVelocidad = 50f ;

    //Dirección en la que va la bola al crearse
    public Vector2 direccion;

    //Referencia a sprites de la pelota
    private Sprite [] sprites;



    // Start is called before the first frame update
    void Start()
    {
        loadIcons();

        gameObject.transform.localScale = new Vector3(tamano, tamano, tamano);
        GetComponent<Rigidbody2D>().velocity = direccion * speed;
        material = GetComponent<CircleCollider2D>().sharedMaterial;

        if (this.player_bounces > 1 && this.sprites.Length >0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }

    }

    void loadIcons()
    {
        string tipo = "";

        string tag = gameObject.tag;

        switch (tag)
        {
            case "YellowBall":
                tipo = "ocio";
                break;
            case "GreenBall":
                tipo = "estudio";
                break;

            default:
                break;
        }


        Sprite[] loadedIcons = Resources.LoadAll<Sprite>("Pelotas");

        if (tipo.Equals("ocio"))
        {
            sprites = Array.FindAll<Sprite>(loadedIcons, i => i.name.Contains("ocio"));
        }else if (tipo.Equals("estudio"))
        {
            sprites = Array.FindAll<Sprite>(loadedIcons, i => i.name.Contains("estudio"));
        }


        

    }
    void FixedUpdate()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();

        if (rigidBody.velocity.magnitude > maxVelocidad)
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocidad);

        if (rigidBody.velocity.magnitude < minVelocidad)
            rigidBody.velocity = rigidBody.velocity.normalized * minVelocidad;

        speed = rigidBody.velocity.magnitude;

        
    }
    
    //Funci�n inicial de prueba
    void Respawn()
    {

        player_bounces = (int)UnityEngine.Random.Range(bounce_min, bounce_max);
        transform.position = Vector3.zero;

        GetComponent<Rigidbody2D>().velocity = UnityEngine.Random.insideUnitCircle.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_bounces--;

            if (player_bounces == 1 && sprites.Length>0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }

        }

        if(player_bounces== 0 || collision.gameObject.CompareTag("Piso"))
        {
            Debug.Log("La pelota ha sido destruida");
            Destroy(gameObject);
            
        }
    }

    public void aumentarVelocidad(float pFactorAumento)
    {

        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * pFactorAumento;
    }

    public void disminuirVelocidad(float pFactorAumento)
    {

        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity / pFactorAumento;
    }

    public void cambiarTamano(float tamano)
    {
        Vector3 nuevoTamano = new Vector3(tamano, tamano, 1);
        GetComponent<Transform>().localScale = nuevoTamano; 
    }

    public void cambiarRebote(float pRebote)
    {
        PhysicsMaterial2D nuevoMaterial = Instantiate(GetComponent<CircleCollider2D>().sharedMaterial);

        nuevoMaterial.bounciness = pRebote;

        GetComponent<CircleCollider2D>().sharedMaterial = nuevoMaterial;

    }
}
