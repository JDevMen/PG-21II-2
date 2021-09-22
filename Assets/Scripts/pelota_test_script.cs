using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelota_test_script : MonoBehaviour
{
    public float speed = 5f;

    public int bounce_min = 1;
    public int bounce_max = 6;

    public int player_bounces =  1;

    public float factorCambioVelocidad = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;

    }

    // Update is called once per frame
    //Se mantiene para motivios de testing y debugging
    void Update()
    {
        //Solo para pruebas
        if (Input.GetKeyDown(KeyCode.F2)) aumentarVelocidad(factorCambioVelocidad);
        if (Input.GetKeyDown(KeyCode.F3)) disminuirVelocidad(factorCambioVelocidad);

        if (Input.GetKeyDown(KeyCode.F4)) cambiarTamano(5f);
        if (Input.GetKeyDown(KeyCode.F5)) cambiarTamano(1f);
        if (Input.GetKeyDown(KeyCode.F6)) cambiarTamano(0.5f);

    }

    void FixedUpdate()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        //Debug.Log(rigidBody.velocity.x);
        //Debug.Log(rigidBody.velocity.y);
        Debug.Log(Mathf.Abs(rigidBody.velocity.x)+ Mathf.Abs(rigidBody.velocity.y));

        
    }
    
    //Funci�n inicial de prueba
    void Respawn()
    {

        player_bounces = (int) Random.Range(bounce_min, bounce_max);
        transform.position = Vector3.zero;

        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_bounces--;
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
}
