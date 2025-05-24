using Questronaut.Inventory;
using System;
using UnityEngine;

namespace Questronaut.Interaction
{
    public class PickeableItemModel : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData _itemData;
        
        public void Interact()
        {
            PlayerInventoryModel.Instance.AddItem(_itemData);
        }

    }
}
