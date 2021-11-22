using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenMusi : MonoBehaviour
{


    public Slider volumenSlider;
    public Camera camaraMenu;
    public static float volumen = 1;

    // Start is called before the first frame update
    void Start()
    {
        volumenSlider.value = volumen;
    }

    // Update is called once per frame
    void Update()
    {
        volumen = volumenSlider.value;
        VolumenMusica(camaraMenu);
    }


    public static void VolumenMusica (Camera camara)
    {
        try
        {
            camara.GetComponent<AudioSource>().volume = volumen;
        }
        catch (System.Exception)
        {

            
        }
        
        
    }

}
