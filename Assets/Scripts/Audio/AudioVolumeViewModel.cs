using UnityEngine;

namespace Questronaut.Audio
{
    public class AudioVolumeViewModel : MonoBehaviour
    {
        [SerializeField] private SoundGroup _soundGroup;
        public SoundGroup SoundGroup => _soundGroup;
    }

    public enum SoundGroup
    {
        MasterVolume,
        MusicVolume,
        SFXVolume
    }
}
