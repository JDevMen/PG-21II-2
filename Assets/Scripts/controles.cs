using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controles : MonoBehaviour
{
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;

    public AudioSource audio;


    public void activateStages()
    {
        bool activeStage1 = stage1.activeSelf;
        bool activeStage2 = stage2.activeSelf;
        bool activeStage3 = stage3.activeSelf;

        if(activeStage1)
        {
            stage1.SetActive(false);
            stage2.SetActive(true);
        }else if (activeStage2)
        {
            stage2.SetActive(false);
            stage3.SetActive(true);
        }else if (activeStage3)
        {
            stage3.SetActive(false);
            SceneManager.LoadScene("Tutorial");   
        }
    }

    private void Update()
    {
        audio.GetComponent<AudioSource>().volume = VolumenMusi.volumen;
    }
}
