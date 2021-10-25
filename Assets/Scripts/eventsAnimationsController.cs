using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventsAnimationsController : MonoBehaviour
{
    public GameObject pelotaEventUI;
    public GameObject jugadorEventUI;

    //Prueba cambio sprite en tiempo de ejecución
    public Sprite pelotaSprite1;
    public Sprite pelotaSprite2;

    //Sprites de eventos
    private Sprite debuffTamanoPelota;


    private Animator pelotaAnimator;
    private Animator jugadorAnimator;
    private SpriteRenderer pelotaEventRenderer;
    private SpriteRenderer jugadorEventRenderer;


    private void Start()
    {
        pelotaAnimator = pelotaEventUI.GetComponent<Animator>();
        jugadorAnimator = jugadorEventUI.GetComponent<Animator>();
        pelotaEventRenderer = pelotaEventUI.GetComponent<SpriteRenderer>();
        jugadorEventRenderer = jugadorEventUI.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Código para probar.
        if (Input.GetKey(KeyCode.F1))
        {
            StartCoroutine(pelotaAnimationCoroutine());
            StartCoroutine(jugadorAnimationCoroutine());
        }
        if (Input.GetKey(KeyCode.F2))
        {
            pelotaEventUI.SetActive(true);
            pelotaAnimator.Play("Default");
            jugadorEventUI.SetActive(true);
            jugadorAnimator.Play("Default");
        }
        if (Input.GetKey(KeyCode.F3))
        {
            Debug.Log("F3 pressed");
            pelotaEventRenderer.sprite = pelotaSprite1;
        }
        if (Input.GetKey(KeyCode.F4))
        {
            Debug.Log("F4 pressed");
            pelotaEventRenderer.sprite = pelotaSprite2;
        }


    }

    public IEnumerator pelotaAnimationCoroutine()
    {
        pelotaAnimator.Play("EventoPelotaAnimation");
        yield return new WaitForSeconds(3f);
        pelotaAnimator.Play("Default");
        pelotaEventUI.SetActive(false);
    }
    public IEnumerator jugadorAnimationCoroutine()
    {
        jugadorAnimator.Play("EventoJugadorAnimation");
        yield return new WaitForSeconds(3f);
        jugadorAnimator.Play("Default");
        jugadorEventUI.SetActive(false);
    }
}
