using UnityEngine;

namespace Questronaut.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        private InventoryViewModel _inventoryViewModel;

        private void Awake()
        {
            _inventoryViewModel = GetComponent<InventoryViewModel>();
        }

        private void Start()
        {
            _inventoryViewModel.OnInventoryToggled += UpdateView;
            UpdateView();
        }

        private void OnDestroy()
        {
            _inventoryViewModel.OnInventoryToggled -= UpdateView;
        }

        private void UpdateView()
        {
            _canvasGroup.alpha = _inventoryViewModel.IsVisible ? 1.0f : 0.0f;
            _canvasGroup.interactable = _inventoryViewModel.IsVisible;
            _canvasGroup.blocksRaycasts = _inventoryViewModel.IsVisible;

        }
    }
}
