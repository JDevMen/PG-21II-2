using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    

    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    public GameObject texto4;
    public GameObject texto5;

    public GameObject verde;
    public GameObject amarillo;
    public GameObject rojo;
    public GameObject evento;


    public void transicionTexto()
    {
        if (texto1.activeSelf == true)
        {
            texto1.SetActive(false);
            texto2.SetActive(true);
        }
        else if (texto2.activeSelf == true)
        {
            texto2.SetActive(false);
            texto3.SetActive(true);
            verde.SetActive(true);
            amarillo.SetActive(true);
            rojo.SetActive(true);
        }
        else if (texto3.activeSelf == true)
        {
            texto3.SetActive(false);
            verde.SetActive(false);
            amarillo.SetActive(false);
            rojo.SetActive(false);
            texto4.SetActive(true);

            evento.SetActive(true);

        }
        else if (texto4.activeSelf == true)
        {
            texto4.SetActive(false);
            
            texto5.SetActive(true);
            
        }
        else if (texto5.activeSelf == true)
        {
            texto5.SetActive(false);
            evento.SetActive(false);
            SceneManager.LoadScene("Controles");
        }
    }
}
