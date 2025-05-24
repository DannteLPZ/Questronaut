using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Inventory
{
    public class InventorySelectionView : MonoBehaviour
    {
        [SerializeField] private Image _selectedItemIcon;
        [SerializeField] private Sprite _emptySprite;
        [SerializeField] private TMP_Text _selectedItemDescription;
        private void Start()
        {
            PlayerInventoryModel.Instance.OnItemSelected += UpdateSelection;
            UpdateSelection(0);
        }

        private void OnDestroy()
        {
            PlayerInventoryModel.Instance.OnItemSelected -= UpdateSelection;
        }

        private void UpdateSelection(int slot)
        {
            if(PlayerInventoryModel.Instance.InventoryData[slot].Item == null)
            {
                _selectedItemIcon.sprite = _emptySprite;
                _selectedItemDescription.SetText("");
            }
            else
            {
                _selectedItemIcon.sprite = PlayerInventoryModel.Instance.InventoryData[slot].Item.Icon;
                _selectedItemDescription.SetText(PlayerInventoryModel.Instance.InventoryData[slot].Item.Description);
            }      
        }
    }
}
