using UnityEngine;
using UnityEngine.EventSystems;

namespace Questronaut.GameFlow
{
    public class PauseGameView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _firstSelected;

        private void Start()
        {
            GameFlowManager.Instance.OnPausedToggled += UpdateView;
            UpdateView();
        }

        private void OnDestroy()
        {
            GameFlowManager.Instance.OnPausedToggled -= UpdateView;
        }

        private void UpdateView()
        {
            if (GameFlowManager.Instance.IsPaused == true)
                EventSystem.current.SetSelectedGameObject(_firstSelected);
            _canvasGroup.alpha = GameFlowManager.Instance.IsPaused ? 1.0f : 0.0f;
            _canvasGroup.interactable = GameFlowManager.Instance.IsPaused;
            _canvasGroup.blocksRaycasts = GameFlowManager.Instance.IsPaused;
        }

    }
}
