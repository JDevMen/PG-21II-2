using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Loader : MonoBehaviour
{

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null) SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    if (!SceneManager.GetSceneByName("UI").isLoaded)
        //        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        //    else SceneManager.UnloadSceneAsync("UI");
        //}
    }
}
