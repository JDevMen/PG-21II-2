using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelota_script : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Función inicial de prueba
    void Respawn()
    {
        transform.position = Vector3.zero;

        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;
    }
}
