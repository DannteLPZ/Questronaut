using UnityEngine;
using UnityEngine.EventSystems;

namespace Questronaut.Inventory
{
    public class InventoryItemSelectionController : MonoBehaviour, ISelectHandler
    {
        private InventoryItemViewModel _inventoryItemViewModel;

        private void Awake()
        {
            _inventoryItemViewModel = GetComponent<InventoryItemViewModel>();
        }

        public void OnSelect(BaseEventData eventData)
        {
            if(EventSystem.current.currentSelectedGameObject == gameObject)
                PlayerInventoryModel.Instance.SelectItem(_inventoryItemViewModel.Slot);
        }
    }
}
