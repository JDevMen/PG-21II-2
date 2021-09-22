using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    public GameObject pelotaPrefab;

    public float minSecondsBetweenSpawning = 3.0f;
    public float maxSecondsBetweenSpawning = 6.0f;

    public float velocidadPelota = 5.0f;
    public int bounce_min = 1;
    public int bounce_max = 6;
    public int player_bounces = 1;

    private float savedTime;
    private float secondsBetweenSpawning;
    private GameObject pelotaCopy;

    // Use this for initialization
    void Start()
    {
        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        //Instanciación inicial del prefab de pelota
        pelotaCopy = Instantiate(pelotaPrefab) ;
        pelotaCopy.GetComponent<pelota_script>().speed = velocidadPelota;
        pelotaCopy.GetComponent<pelota_script>().bounce_min = bounce_min;
        pelotaCopy.GetComponent<pelota_script>().bounce_max = bounce_max;
        pelotaCopy.GetComponent<pelota_script>().player_bounces = player_bounces;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
        {
            //Instanciación del prefab para generar una nueva pelota
            pelotaCopy = Instantiate(pelotaPrefab);
            pelotaCopy.GetComponent<pelota_script>().speed = velocidadPelota;
            pelotaCopy.GetComponent<pelota_script>().bounce_min = bounce_min;
            pelotaCopy.GetComponent<pelota_script>().bounce_max = bounce_max;
            pelotaCopy.GetComponent<pelota_script>().player_bounces = player_bounces;
            MakeThingToSpawn();
            savedTime = Time.time; // store for next spawn
            secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        }
    }

    void MakeThingToSpawn()
    {
        
        // create a new gameObject
        GameObject clone = Instantiate(pelotaCopy, transform.position, transform.rotation) as GameObject;

    }
}
