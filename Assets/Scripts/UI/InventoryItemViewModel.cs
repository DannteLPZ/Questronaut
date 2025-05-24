using UnityEngine;

namespace Questronaut.Inventory
{
    public class InventoryItemViewModel : MonoBehaviour
    {
        [SerializeField] private int _itemSlot;
        public int Slot => _itemSlot;
    }
}