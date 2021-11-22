using System.Collections;
using System.Collections.Generic;
 using UnityEngine.SceneManagement;

using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("Audio");
 

        if(musicObject.Length >1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
     }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
       if (scene.name == "Menu") {
                        Debug.Log("I am inside the if statement");

             Destroy(this.gameObject);
       }
 }
}
