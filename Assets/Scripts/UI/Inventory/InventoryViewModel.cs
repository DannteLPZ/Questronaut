using Questronaut.Player;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Questronaut.Inventory
{
    public class InventoryViewModel : MonoBehaviour
    {

        public event Action OnInventoryToggled;
        private bool _isVisible;
        public bool IsVisible => _isVisible;

        private GameObject _firstSelectedObject;
        private void Awake()
        {
            _firstSelectedObject = FindObjectsByType<InventoryItemViewModel>(FindObjectsSortMode.None).FirstOrDefault(t => t.Slot == 0).gameObject;
        }

        public void ToggleInventory()
        {
            _isVisible = !_isVisible;
            if (_isVisible == true)
            {
                EventSystem.current.SetSelectedGameObject(_firstSelectedObject);
                PlayerInventoryModel.Instance.SelectItem(0);
                PlayerBlockerModel.Instance.BlockPlayer();
            }
            else
                PlayerBlockerModel.Instance.UnblockPlayer();

            OnInventoryToggled?.Invoke();
        }
    }
}
