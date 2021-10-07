using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscenarios : MonoBehaviour
{

    public GameObject esce1;
    public GameObject esce2;
    public GameObject esce3;
    public GameObject esce4;

    public void CargarMenu()
    {
        Debug.Log("click");
        SceneManager.LoadScene(0);
        
    }



    // Start is called before the first frame update
    void Start()
    {
        int escenario = EvaluacionPuntaje.escenarioCargar;
        Debug.Log(escenario);

        if (escenario == 1)
        {
            esce1.SetActive(true);
        }
        else if (escenario == 2)
        {
            esce2.SetActive(true);
        }
        else if (escenario == 3)
        {
            esce3.SetActive(true);
        }
        else if (escenario == 4)
        {
            esce4.SetActive(true);
        }


    }


}
