using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Audio
{
    [RequireComponent (typeof (Button))]
    public class ButtonPlayAudioController : MonoBehaviour
    {
        [SerializeField] private string _soundName = "SFX_Button";
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(PlayAudio);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(PlayAudio);
        }

        private void PlayAudio()
        {
            AudioManager.Instance.PlaySound(_soundName);
        }
    }
}
