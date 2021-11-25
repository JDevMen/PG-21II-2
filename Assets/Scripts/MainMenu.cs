using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip clickSound;

    public void Jugar ()
    { 
        StartCoroutine(SelectJugar());    
    }

    public void Tutorial ()
    {
       StartCoroutine( SelectTutorial());     
    }

    IEnumerator SelectJugar()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        AudioSource audioSource = camera.GetComponent<AudioSource>();
        audioSource.clip= clickSound;
        audioSource.Play(); 
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Intro"); 
    }
    
    IEnumerator SelectTutorial()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        AudioSource audioSource = camera.GetComponent<AudioSource>();
        audioSource.clip= clickSound;
        audioSource.Play(); 
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Controles"); 
    }



}
