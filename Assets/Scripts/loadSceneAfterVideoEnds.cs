using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneAfterVideoEnds : MonoBehaviour
{

    public VideoPlayer videoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Intro BalanceUNIversal_Trim.mp4");
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Entró a EndReached");

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
