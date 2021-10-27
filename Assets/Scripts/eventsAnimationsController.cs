using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class eventsAnimationsController : MonoBehaviour
{
    public GameObject pelotaEventUI;
    public GameObject jugadorEventUI;

    private Animator pelotaAnimator;
    private Animator jugadorAnimator;

    //Lista de sprites de todos los iconos,
    //iconos predeterminados en pos 0 y 1
    private Sprite[] icons;


    private void Start()
    {
        pelotaAnimator = pelotaEventUI.GetComponent<Animator>();
        jugadorAnimator = jugadorEventUI.GetComponent<Animator>();

        loadIcons();

        Debug.Log(icons[0]);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            pelotaAnimator.Play("lookAtMe");
        }

        if(Input.GetKey(KeyCode.F2))
        {
            changeBallEventSprite("ballEvent1");
        }
        if (Input.GetKey(KeyCode.F3))
        {
            changePlayerEventSprite("playerEvent1");
        }


    }

    public IEnumerator pelotaAnimationCoroutine(float pDuracion)
    {
        pelotaAnimator.Play("lookAtMe");
        yield return new WaitForSeconds(pDuracion);
        pelotaAnimator.Play("Default");
    }
    public IEnumerator jugadorAnimationCoroutine(float pDuracion)
    {
        Debug.Log("Entró jugadorAnimationCoroutine");
        jugadorAnimator.Play("lookAtMe");
        yield return new WaitForSeconds(pDuracion);
        jugadorAnimator.Play("Default");
    }

    void loadIcons()
    {
        object[] loadedIcons = Resources.LoadAll<Sprite>("EventIcons");

        icons = new Sprite[loadedIcons.Length];

        for(int i = 0; i<icons.Length;i++)
        {
            icons[i] = (Sprite)loadedIcons[i];
        }

    }

    public void changeBallEventSprite(string pNombre)
    {
        Sprite nuevo = Array.Find(icons, i => i.name == pNombre);

        pelotaEventUI.GetComponent<Image>().sprite = nuevo;

    }
    public void changePlayerEventSprite(string pNombre)
    {
        Sprite nuevo = Array.Find(icons, i => i.name == pNombre);

        jugadorEventUI.GetComponent<Image>().sprite = nuevo;

    }

}
