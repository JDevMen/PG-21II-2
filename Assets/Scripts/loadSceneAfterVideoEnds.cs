using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneAfterVideoEnds : MonoBehaviour
{

    public VideoPlayer videoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Entr� a EndReached");

        SceneManager.LoadScene("Juego");
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Juego");
        }
    }
}
