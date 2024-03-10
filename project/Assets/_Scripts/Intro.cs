
using Game.Controller;
using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public VideoPlayer vid;

    void Start() { vid.loopPointReached += CheckOver; }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManagement.MoveToScene("level0");
    }

}