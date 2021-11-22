using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {



        if (scene.name == "Menu")
        {
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.Stop();
        }

    }
}