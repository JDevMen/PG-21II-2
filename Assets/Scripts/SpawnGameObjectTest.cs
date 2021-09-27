using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjectTest : MonoBehaviour
{
    public GameObject pelotaPrefab;
    public GameObject reticle;

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
        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 reticlePos = reticle.transform.position;

        direction = reticlePos - (Vector2)transform.position;

        if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
        {
            //Instanciación del prefab para generar una nueva pelota
            shootObject();
            savedTime = Time.time; // store for next spawn
            secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        }
    }

    void shootObject()
    {
        //Instanciación del prefab para generar una nueva pelota
        GameObject pelotaCopy = Instantiate(pelotaPrefab, reticle.transform.position, Quaternion.identity);
        pelotaCopy.GetComponent<pelota_test_script>().speed = velocidadPelota;

        pelotaCopy.GetComponent<pelota_test_script>().bounce_min = bounce_min;
        pelotaCopy.GetComponent<pelota_test_script>().bounce_max = bounce_max;
        pelotaCopy.GetComponent<pelota_test_script>().player_bounces = player_bounces;
        pelotaCopy.GetComponent<pelota_test_script>().direccion = direction;
    }
}
