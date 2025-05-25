using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Dialog
{
    public class DialogContinueController : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(ContinueDialog);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ContinueDialog);
        }

        private void ContinueDialog()
        {
            DialogManager.Instance.HideDialog();
        }
    }
}
