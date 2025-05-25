using Questronaut.GameFlow;
using UnityEngine;

namespace Questronaut.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        private InventoryViewModel _inventoryViewModel;

        private bool CanInput => !GameFlowManager.Instance.IsPaused;

        private void Awake()
        {
            _inventoryViewModel = GetComponent<InventoryViewModel>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) == true && CanInput == true)
                _inventoryViewModel.ToggleInventory();
        }
    }
}
