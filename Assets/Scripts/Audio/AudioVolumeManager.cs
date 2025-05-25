using UnityEngine;
using UnityEngine.Audio;

namespace Questronaut.Audio
{
    public class AudioVolumeManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public static AudioVolumeManager Instance;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SetVolume(SoundGroup.MasterVolume, PlayerPrefs.GetFloat(SoundGroup.MasterVolume.ToString(), 0.0f));
            SetVolume(SoundGroup.MusicVolume, PlayerPrefs.GetFloat(SoundGroup.MusicVolume.ToString(), 0.0f));
            SetVolume(SoundGroup.SFXVolume, PlayerPrefs.GetFloat(SoundGroup.SFXVolume.ToString(), 0.0f));
        }

        public void SetVolume(SoundGroup soundGroup, float volume)
        {
            _audioMixer.SetFloat(soundGroup.ToString(), volume);
            PlayerPrefs.SetFloat(soundGroup.ToString(), volume);
        }
    }
}
