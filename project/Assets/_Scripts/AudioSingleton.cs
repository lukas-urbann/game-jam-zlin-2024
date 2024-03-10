using UnityEngine;

namespace Game
{
    public class AudioSingleton : MonoBehaviour
    {
        public static AudioSingleton instance;
        public AudioSource audioSource;
        public AudioClip interactSound;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }

        public void PlaySound(AudioClip clip)
        {
            if(audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.clip = clip;
            audioSource.Play();
        }

        public void PlaySoundOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
