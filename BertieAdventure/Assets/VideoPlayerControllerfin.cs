using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class VideoPlayerControllerfin : MonoBehaviour

{
    void Start()
    {
       
        GameObject camera = GameObject.Find("Main Camera");

        
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

       
        videoPlayer.playOnAwake = false;

        
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        
        videoPlayer.targetCameraAlpha = 0.5F;

        
        videoPlayer.url = "Assets/Animatique de fin";

        
        videoPlayer.frame = 100;

        
        videoPlayer.isLooping = true;

        
        videoPlayer.loopPointReached += EndReached;

        
        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        SceneManager.LoadScene("TestProg");
    }
}


