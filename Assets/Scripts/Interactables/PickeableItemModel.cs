using Questronaut.Inventory;
using System;
using UnityEngine;
using UnityEngine.UI;

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

    [Serializable]
    public class ItemData
    {
        public string Name;
        public string Description;
        public int MaxStackSize;
        public Image Icon;
    }
}
