using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        public AudioSource source;
        public List<AudioClip> clip = new();

        public void PlayRandomSoundFromList()
        {
            int rIndex = Random.Range(0, clip.Count);
            source.PlayOneShot(clip[rIndex]);
        }
    }
}
