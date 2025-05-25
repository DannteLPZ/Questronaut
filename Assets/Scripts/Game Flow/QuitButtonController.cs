using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.GameFlow
{
    [RequireComponent(typeof(Button))]
    public class QuitButtonController : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(QuitGame);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(QuitGame);
        }

        private void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
