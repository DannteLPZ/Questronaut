using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Audio
{
    public class AudioVolumeController : MonoBehaviour
    {
        private AudioVolumeViewModel _volumeViewModel;
        private Slider _volumeSlider;

        private void Awake()
        {
            _volumeViewModel = GetComponent<AudioVolumeViewModel>();
            _volumeSlider = GetComponent<Slider>();
        }

        private void Start()
        {
            _volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(_volumeViewModel.SoundGroup.ToString(), 0.0f));
            _volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        private void OnDestroy()
        {
            _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        }

        private void ChangeVolume(float value)
        {
            AudioVolumeManager.Instance.SetVolume(_volumeViewModel.SoundGroup, value);
        }
    }
}
