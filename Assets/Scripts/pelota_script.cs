using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelota_script : MonoBehaviour
{
    public float speed = 5f;

    public float bounce_min = 1f;
    public float bounce_max = 6f;

    public int player_bounces =  1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
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
            Respawn();

            
        }
    }
}
