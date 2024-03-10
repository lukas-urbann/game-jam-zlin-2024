using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingletonCaller : MonoBehaviour
{
    public AudioClip toCall;

    public void PlayAudio()
    {
        AudioSingleton.instance.PlaySound(toCall);
    }
}
