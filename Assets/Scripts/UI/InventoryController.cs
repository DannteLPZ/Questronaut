using UnityEngine;

namespace Questronaut.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        private InventoryViewModel _inventoryViewModel;

        private void Awake()
        {
            _inventoryViewModel = GetComponent<InventoryViewModel>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) == true)
                _inventoryViewModel.ToggleInventory();
        }
    }
}
