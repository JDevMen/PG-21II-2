using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventsAnimationsController : MonoBehaviour
{
    public GameObject pelotaEventUI;
    public GameObject jugadorEventUI;

    private Animator pelotaAnimator;
    private Animator jugadorAnimator;

    private void Start()
    {
        pelotaAnimator = pelotaEventUI.GetComponent<Animator>();
        jugadorAnimator = jugadorEventUI.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Código para probar.
        if (Input.GetKey(KeyCode.F1))
        {
            StartCoroutine(pelotaAnimationCoroutine());
        }
        if (Input.GetKey(KeyCode.F2))
        {
            pelotaEventUI.SetActive(true);
            pelotaAnimator.Play("Default");
        }
    }

    IEnumerator pelotaAnimationCoroutine()
    {
        pelotaAnimator.Play("EventoPelotaAnimation");
        yield return new WaitForSeconds(3f);
        pelotaAnimator.Play("Default");
        pelotaEventUI.SetActive(false);
    }
}
