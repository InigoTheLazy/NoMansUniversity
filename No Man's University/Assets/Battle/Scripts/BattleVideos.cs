using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BattleVideos : MonoBehaviour
{
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(string name, float vidtim)
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCameraAlpha = 2.5F;
        canvas.SetActive(false);
        videoPlayer.url = name;
        videoPlayer.Play();
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
