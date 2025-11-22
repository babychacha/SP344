using UnityEngine;
using UnityEngine.Video;

public class PlayVideoNow : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
