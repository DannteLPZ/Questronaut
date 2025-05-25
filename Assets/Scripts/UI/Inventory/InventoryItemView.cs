using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Sprite _emptySlotSprite;

        [SerializeField] private Image _selectedImage;
        [SerializeField] private Sprite _selectedSprite;
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private Button _itemButton;

        private InventoryItemViewModel _inventoryItemViewModel;

        private void Awake()
        {
            _inventoryItemViewModel = GetComponent<InventoryItemViewModel>();
        }

        private void Start()
        {
            PlayerInventoryModel.Instance.OnItemDataChanged += UpdateView;
            PlayerInventoryModel.Instance.OnItemSelected += UpdateSelection;
            UpdateView(_inventoryItemViewModel.Slot);
        }

        private void OnDestroy()
        {
            PlayerInventoryModel.Instance.OnItemDataChanged -= UpdateView;
            PlayerInventoryModel.Instance.OnItemSelected -= UpdateSelection;
        }

        private void UpdateView(int slotChanged)
        {
            if (slotChanged != _inventoryItemViewModel.Slot)
                return;
            InventoryItem inventoryItem = PlayerInventoryModel.Instance.InventoryData[_inventoryItemViewModel.Slot];

            if (inventoryItem.Item == null)
            {
                _iconImage.sprite = _emptySlotSprite;
                _amountText.SetText("");
                _itemButton.interactable = false;
            }
            else
            {
                _iconImage.sprite = inventoryItem.Item.Icon;
                _amountText.SetText(inventoryItem.CurrentAmount.ToString());
                _itemButton.interactable = true;
            }
        }

        private void UpdateSelection(int slotSelected)
        {
            InventoryItem inventoryItem = PlayerInventoryModel.Instance.InventoryData[_inventoryItemViewModel.Slot];
            if (slotSelected != _inventoryItemViewModel.Slot || inventoryItem.Item == null)
                _selectedImage.sprite = _emptySlotSprite;
            else
                _selectedImage.sprite = _selectedSprite;
        }
    }
}
