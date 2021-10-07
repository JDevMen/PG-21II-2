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
        }
        else if (texto3.activeSelf == true)
        {
            texto3.SetActive(false);
            texto4.SetActive(true);
        }
        else if (texto4.activeSelf == true)
        {
            texto4.SetActive(false);
            texto5.SetActive(true);
        }
        else if (texto5.activeSelf == true)
        {
            texto5.SetActive(false);
            SceneManager.LoadScene("Juego");
        }
    }
}
