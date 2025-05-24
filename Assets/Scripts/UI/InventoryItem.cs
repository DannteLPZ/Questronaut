using Questronaut.Interaction;
using System;

namespace Questronaut.Inventory
{
    [Serializable]
    public class InventoryItem
    {
        public ItemData Item;
        public int CurrentAmount;

        public InventoryItem(ItemData item, int currentAmount = 0)
        {
            Item = item;
            CurrentAmount = currentAmount;
        }

        public bool IsFull => CurrentAmount >= Item.MaxStackSize;
        public bool IsEmpty => Item == null; //string.IsNullOrEmpty(Item.Name);
    }

}