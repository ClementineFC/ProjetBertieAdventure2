using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class VideoPlayerController : MonoBehaviour

{
    public VideoPlayer videoPlayer;
    void Start()
    {

        GameObject camera = GameObject.Find("Main Camera");


        videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();


        videoPlayer.playOnAwake = false;


        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;


        videoPlayer.targetCameraAlpha = 0.5F;


        videoPlayer.url = "Assets/animatique";


        videoPlayer.frame = 100;


        //videoPlayer.isLooping = true;


        videoPlayer.loopPointReached += EndReached;

        videoPlayer.Play();



    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            finAnimation();
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        SceneManager.LoadScene("TestProg");

    }

    void finAnimation()
    {
        SceneManager.LoadScene("TestProg");
    }
}


