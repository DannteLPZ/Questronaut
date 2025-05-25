using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.GameFlow
{
    [RequireComponent(typeof(Button))]
    public class ChangeSceneController : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(ChangeScene);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ChangeScene);
        }

        private void ChangeScene()
        {
            SceneLoader.Instance.LoadScene(_sceneIndex);
        }
    }
}
