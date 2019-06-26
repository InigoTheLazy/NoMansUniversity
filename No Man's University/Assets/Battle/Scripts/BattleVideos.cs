using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BattleVideos : MonoBehaviour
{
    public GameObject canvas;
    
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Prepare();
    }

    public void PlayVideo(string name, float vidtim, bool tf)
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCameraAlpha = 1F;
        canvas.SetActive(false);
        videoPlayer.url = name;
        videoPlayer.Play();
        if (tf)
            Invoke("CanvasOn", vidtim);
        Destroy(videoPlayer, vidtim);
    }

    private void CanvasOn()
    {
        canvas.SetActive(true);
    }

    public void StopVideo()
    {
        GameObject camera = GameObject.Find("Main Camera");
        Destroy(camera.GetComponent<VideoPlayer>());
    }
}
