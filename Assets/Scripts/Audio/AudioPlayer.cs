using System.Collections;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource[] sfxSource;

        private void Awake()
        {
            ServiceLocator.RegisterAudioManager(this);
        }
        
        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }

        public void PlaySFX(AudioClip clip)
        {
            for (int i = 0; i < sfxSource.Length; i++)
            {
                if (sfxSource[i].clip == null && clip != null)
                {
                    sfxSource[i].clip = clip;
                    sfxSource[i].PlayOneShot(clip);
                    StartCoroutine(ClearClip(sfxSource[i], clip.length));
                    return;
                }
            }
        }

        public void SetMusicVolume(float volume)
        {
            musicSource.volume = volume;
        }

        public void SetSFXVolume(float volume)
        {
            for (int i = 0; i < sfxSource.Length; i++)
            {
                sfxSource[i].volume = volume;
            }
        }

        IEnumerator ClearClip(AudioSource audioSource, float time)
        {
            yield return new WaitForSeconds(time);
            audioSource.clip = null;
        }
    }
}
