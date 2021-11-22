using UnityEngine.Video;
using UnityEngine;

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
        Debug.Log("Entró a EndReached");

        UnityEngine.SceneManagement.SceneManager.LoadScene("Juego");
    }
}
