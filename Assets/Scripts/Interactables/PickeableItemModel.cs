using Questronaut.Inventory;
using UnityEngine;

namespace Questronaut.Interaction
{
    public class PickeableItemModel : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemDataSO _itemData;
        
        public void Interact()
        {
            PlayerInventoryModel.Instance.AddItem(_itemData);
            Destroy(gameObject);
        }

    }
}
