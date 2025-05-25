using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Dialog
{
    public class DialogView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _firstSelected;

        [SerializeField] private Image _portraitFillImage;
        [SerializeField] private TMP_Text _dialogText;

        private void Start()
        {
            DialogManager.Instance.OnShowDialog += ShowDialog;
            DialogManager.Instance.OnHideDialog += HideDialog;

            HideDialog();
        }

        private void OnDestroy()
        {
            DialogManager.Instance.OnShowDialog -= ShowDialog;
            DialogManager.Instance.OnHideDialog -= HideDialog;
        }

        private void ShowDialog()
        {
            _portraitFillImage.color = DialogManager.Instance.CurrentNPCData.Color;
            _dialogText.SetText(DialogManager.Instance.CurrentNPCData.Dialog);

            _canvasGroup.alpha = 1.0f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        private void HideDialog()
        {
            _canvasGroup.alpha = 0.0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}
