using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_script : MonoBehaviour
{
    public float speed = 5f;

    private float input;

    public float points = 0f;

    //Puntos del jugador
    public float puntosEnergia = 0f;
    public float puntosUniversidad = 0f;
    public float puntosFamilia = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * input * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pelotas"))
        {
            points++;
            puntosEnergia -= 0.25f;
            puntosUniversidad -= 0.25f;
            puntosFamilia -= 0.25f;
            
        }

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
