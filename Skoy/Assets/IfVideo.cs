using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IfVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneName;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnded;
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneName);
    }
}
