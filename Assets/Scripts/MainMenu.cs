using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jugar ()
    {
        SceneManager.LoadScene("Intro");
    }


    public void Salir ()
    {
        Debug.Log("Salir");
        Application.Quit();

    }

}
