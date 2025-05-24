using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _amountText;

        private InventoryItemViewModel _inventoryItemViewModel;

        private void Awake()
        {
            _inventoryItemViewModel = GetComponent<InventoryItemViewModel>();
        }

        private void Start()
        {
            PlayerInventoryModel.Instance.OnItemSlotChanged += UpdateView;
        }

        private void OnDestroy()
        {
            PlayerInventoryModel.Instance.OnItemSlotChanged -= UpdateView;
        }

        private void UpdateView(int slotChanged)
        {
            if (slotChanged != _inventoryItemViewModel.Slot)
                return;
            InventoryItem inventoryItem = PlayerInventoryModel.Instance.InventoryData[_inventoryItemViewModel.Slot];

            _iconImage.sprite = inventoryItem.Item.Icon;
            _amountText.SetText(inventoryItem.CurrentAmount.ToString());
        }
    }
}
