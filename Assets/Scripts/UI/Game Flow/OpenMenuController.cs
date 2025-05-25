using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Questronaut.GameFlow
{
    public class OpenMenuController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _groupToHide;
        [SerializeField] private CanvasGroup _groupToShow;
        [SerializeField] private GameObject _firstSelected;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(OpenMenu);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OpenMenu);
        }

        private void OpenMenu()
        {
            _groupToHide.interactable = false;
            _groupToHide.blocksRaycasts = false;
            _groupToHide.alpha = 0.0f;

            EventSystem.current.SetSelectedGameObject(_firstSelected);

            _groupToShow.alpha = 1.0f;
            _groupToShow.interactable = true;
            _groupToShow.blocksRaycasts = true;
        }
    }
}
