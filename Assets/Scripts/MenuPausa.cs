using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    
    public static bool estaPausado = false;

    public GameObject menuPausaUI;
    public Button botonPausa;

    // Start is called before the first frame update
    void Start()
    {
        Button boton = botonPausa.GetComponent<Button>();
        boton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (estaPausado)
        {
            Continuar();
        }
        else
        {
            Pausar();
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(estaPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }


    public void Continuar () {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    void Pausar () {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;
    }


    public void cargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void salir ()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }



}
