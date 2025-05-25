using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

namespace Questronaut.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private List<Sound> _allSounds;
        [SerializeField] private AudioMixerGroup _musicGroup;
        [SerializeField] private AudioMixerGroup _sfxGroup;

        public static AudioManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            foreach (Sound sound in _allSounds)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = sound.AudioClip;
                audioSource.volume = sound.Volume;
                audioSource.pitch = sound.Pitch;
                audioSource.loop = sound.Loop;

                if (sound.Name.StartsWith("M_") == true)
                    audioSource.outputAudioMixerGroup = _musicGroup;
                else
                    audioSource.outputAudioMixerGroup = _sfxGroup;

                sound.AudioSource = audioSource;
            }
        }

        private void Start()
        {
            PlaySound("M_Background");
        }

        public void PlaySound(string name)
        {
            Sound foundSound = _allSounds.Where(t => t.Name == name).FirstOrDefault();
            if (foundSound == null)
            {
                Debug.Log($"Sound {name} not found.");
                return;
            }
            foundSound.AudioSource.Play();
        }

        public void StopSound(string name)
        {
            Sound foundSound = _allSounds.Where(t => t.Name == name).FirstOrDefault();
            if (foundSound == null)
            {
                Debug.Log($"Sound {name} not found.");
                return;
            }
            foundSound.AudioSource.Stop();
        }

        [Serializable]
        public class Sound
        {
            public string Name;
            public AudioClip AudioClip;
            [Range(0.0f, 1.0f)] public float Volume;
            [Range(-3.0f, 3.0f)] public float Pitch;
            public bool Loop;

            [HideInInspector]
            public AudioSource AudioSource;
            
        }
    }
}
